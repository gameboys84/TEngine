using System;
using Cysharp.Threading.Tasks;
using Launcher;
using TEngine;
using TEngine.Localization;
using UnityEngine;
using YooAsset;
using ProcedureOwner = TEngine.IFsm<TEngine.IProcedureModule>;
using Utility = TEngine.Utility;

namespace Procedure
{
    /// <summary>
    /// 3. 流程 => 初始化Package。 => InitResources
    /// </summary>
    public class ProcedureInitPackage : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        private ProcedureOwner _procedureOwner;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            _procedureOwner = procedureOwner;

            //Fire Forget立刻触发UniTask初始化Package
            InitPackage(procedureOwner).Forget();
        }

        private async UniTaskVoid InitPackage(ProcedureOwner procedureOwner)
        {
            try
            {
                var initializationOperation = await _resourceModule.InitPackage(_resourceModule.DefaultPackageName);

                if (initializationOperation.Status == EOperationStatus.Succeed)
                {
                    EPlayMode playMode = _resourceModule.PlayMode;

                    // 编辑器模式。
                    if (playMode == EPlayMode.EditorSimulateMode)
                    {
                        Log.Info("Editor resource mode detected.");
                        ChangeState<ProcedureInitResources>(procedureOwner);
                    }
                    // 单机模式。
                    else if (playMode == EPlayMode.OfflinePlayMode)
                    {
                        Log.Info("Package resource mode detected.");
                        ChangeState<ProcedureInitResources>(procedureOwner);
                    }
                    // 可更新模式。
                    else if (playMode == EPlayMode.HostPlayMode ||
                             playMode == EPlayMode.WebPlayMode)
                    {
                        // 打开启动UI。
                        LauncherMgr.ShowUI<LoadUpdateUI>();

                        Log.Info("Updatable resource mode detected.");
                        ChangeState<ProcedureInitResources>(procedureOwner);
                    }
                    else
                    {
                        Log.Error("UnKnow resource mode detected Please check???");
                    }
                }
                else
                {
                    // 打开启动UI。
                    LauncherMgr.ShowUI<LoadUpdateUI>();

                    Log.Error($"{initializationOperation.Error}");

                    // 打开启动UI。
                    LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_InitResourcesFailed);

                    LauncherMgr.ShowMessageBox(Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_InitResourcesFailedRetryWithReason, initializationOperation.Error),
                        () => { Retry(procedureOwner); }, UnityEngine.Application.Quit);
                }
            }
            catch (Exception e)
            {
                OnInitPackageFailed(procedureOwner, e.Message);
            }
        }

        private void OnInitPackageFailed(ProcedureOwner procedureOwner, string message)
        {
            // 打开启动UI。
            LauncherMgr.ShowUI<LoadUpdateUI>();

            Log.Error($"{message}");

            // 打开启动UI。
            LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_InitResourcesFailed);

            if (message.Contains("PackageManifest_DefaultPackage.version Error : HTTP/1.1 404 Not Found"))
            {
                message = Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_CheckFileExists, "StreamingAssets/package/DefaultPackage/PackageManifest_DefaultPackage.version");
            }

            LauncherMgr.ShowMessageBox(
                Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_InitResourcesFailedRetryWithReason, message),
                () => { Retry(procedureOwner); },
                Application.Quit);
        }

        private void Retry(ProcedureOwner procedureOwner)
        {
            // 打开启动UI。
            LauncherMgr.ShowUI<LoadUpdateUI>( ScriptLocalization.LC_LAUNCHER_ReinitResources);

            InitPackage(procedureOwner).Forget();
        }
    }
}