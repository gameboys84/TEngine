using System.Collections;
using Launcher;
using TEngine;
using TEngine.Localization;
using UnityEngine;
using YooAsset;
using ProcedureOwner = TEngine.IFsm<TEngine.IProcedureModule>;

namespace Procedure
{
    /// <summary>
    /// 4. 初始化资源, => CreateDownloader or Preload
    /// </summary>
    public class ProcedureInitResources : ProcedureBase
    {
        private bool _initResourcesComplete = false;

        public override bool UseNativeDialog => true;

        private ProcedureOwner _procedureOwner;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            _procedureOwner = procedureOwner;

            base.OnEnter(procedureOwner);

            _initResourcesComplete = false;

            LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_InitResources);

            // 注意：使用单机模式并初始化资源前，需要先构建 AssetBundle 并复制到 StreamingAssets 中，否则会产生 HTTP 404 错误
            Utility.Unity.StartCoroutine(InitResources(procedureOwner));
        }

        private void ChangeToCreateDownloaderState(ProcedureOwner procedureOwner)
        {
            ChangeState<ProcedureCreateDownloader>(procedureOwner);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!_initResourcesComplete)
            {
                // 初始化资源未完成则继续等待
                return;
            }

            if (_resourceModule.PlayMode == EPlayMode.HostPlayMode || _resourceModule.PlayMode == EPlayMode.WebPlayMode)
            {
                //线上最新版本operation.PackageVersion
                Log.Debug($"Updated package Version : from {_resourceModule.GetPackageVersion()} to {_resourceModule.PackageVersion}");
                //注意：保存资源版本号作为下次默认启动的版本!
                // 如果当前是WebGL或者是边玩边下载直接进入预加载阶段。
                if (_resourceModule.PlayMode == EPlayMode.WebPlayMode ||
                    _resourceModule.UpdatableWhilePlaying)
                {
                    // 边玩边下载还可以拓展首包支持。
                    ChangeToPreloadState(procedureOwner);
                    return;
                }

                ChangeToCreateDownloaderState(procedureOwner);
                return;
            }

            ChangeToPreloadState(procedureOwner);
        }

        //// <summary>
        /// 初始化资源流程。
        /// <remarks>YooAsset 需要保持编辑器、单机、联机模式流程一致。</remarks>
        private IEnumerator InitResources(ProcedureOwner procedureOwner)
        {
            Log.Info("更新资源清单！！！");
            LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_UpdateManifest);

            // 1. 获取资源清单的版本信息
            var operation1 = _resourceModule.RequestPackageVersionAsync();
            yield return operation1;
            if (operation1.Status != EOperationStatus.Succeed)
            {
                Log.Error($"获取资源清单版本失败！ {operation1.Error}");
                OnInitResourcesError(procedureOwner, "");
                yield break;
            }

            var packageVersion = operation1.PackageVersion;
            _resourceModule.PackageVersion = packageVersion;

            if (Utility.PlayerPrefs.HasKey("GAME_VERSION"))
            {
                Utility.PlayerPrefs.SetString("GAME_VERSION", _resourceModule.PackageVersion);
            }

            Log.Info($"Init resource package version : {packageVersion}");

            // 2. 传入的版本信息更新资源清单
            var operation2 = _resourceModule.UpdatePackageManifestAsync(packageVersion);
            yield return operation2;
            if (operation2.Status != EOperationStatus.Succeed)
            {
                Log.Error($"更新资源清单失败！ {operation2.Error}");
                OnInitResourcesError(procedureOwner, "");
                yield break;
            }

            _initResourcesComplete = true;
        }

        private void ChangeToPreloadState(ProcedureOwner procedureOwner)
        {
            ChangeState<ProcedurePreload>(procedureOwner);
        }

        private void OnInitResourcesError(ProcedureOwner procedureOwner, string message)
        {
            // 检查设备网络连接状态。
            if (_resourceModule.PlayMode == EPlayMode.HostPlayMode)
            {
                if (!IsNeedUpdate())
                {
                    return;
                }
                else
                {
                    LauncherMgr.ShowMessageBox(
                        ScriptLocalization.LC_LAUNCHER_Title_Error, 
                        Utility.Text.LocaleFormat(ScriptTerms.LC_LAUNCHER_GetRemoteVersionFailed, message),
                        () => { Utility.Unity.StartCoroutine(InitResources(procedureOwner)); },
                        Application.Quit);
                    return;
                }
            }
            
            LauncherMgr.ShowMessageBox(
                ScriptLocalization.LC_LAUNCHER_Title_Error,
                Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_InitResourcesFailedRetryWithReason, message),
                () => { Utility.Unity.StartCoroutine(InitResources(procedureOwner)); }, Application.Quit);
        }

        private bool IsNeedUpdate()
        {
            // 如果不能联网且当前游戏非强制(不更新可以进入游戏。)
            if (Settings.UpdateSetting.UpdateStyle == UpdateStyle.Optional && !_resourceModule.UpdatableWhilePlaying)
            {
                // 获取上次成功记录的版本
                string packageVersion = Utility.PlayerPrefs.GetString("GAME_VERSION", string.Empty);
                if (string.IsNullOrEmpty(packageVersion))
                {
                    LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_Net_UnReachable);
                    LauncherMgr.ShowMessageBox(
                        ScriptLocalization.LC_LAUNCHER_Title_Error, 
                        ScriptLocalization.LC_LAUNCHER_NoLocalVersion,
                        () => { Utility.Unity.StartCoroutine(InitResources(_procedureOwner)); },
                        Application.Quit);
                    return false;
                }

                _resourceModule.PackageVersion = packageVersion;

                if (Settings.UpdateSetting.UpdateNotice == UpdateNotice.Notice)
                {
                    LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_Load_Notice);
                    LauncherMgr.ShowMessageBox(
                        ScriptLocalization.LC_LAUNCHER_Title_Error,
                        ScriptLocalization.LC_LAUNCHER_UpdateFailedOptional,
                        () => { Utility.Unity.StartCoroutine(InitResources(_procedureOwner)); },
                        () => { ChangeState<ProcedurePreload>(_procedureOwner); });
                }
                else
                {
                    ChangeState<ProcedurePreload>(_procedureOwner);
                }

                return false;
            }

            return true;
        }
    }
}