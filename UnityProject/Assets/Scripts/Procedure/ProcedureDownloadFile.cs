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
    public class ProcedureDownloadFile : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        private ProcedureOwner _procedureOwner;

        private float _lastUpdateDownloadedSize;
        private float _totalSpeed;
        private int _speedSampleCount;

        private float CurrentSpeed
        {
            get
            {
                float interval = Math.Max(Time.deltaTime, 0.01f); // 防止deltaTime过小
                var sizeDiff = _resourceModule.Downloader.CurrentDownloadBytes - _lastUpdateDownloadedSize;
                _lastUpdateDownloadedSize = _resourceModule.Downloader.CurrentDownloadBytes;
                var speed = sizeDiff / interval;

                // 使用滑动窗口计算平均速度
                _totalSpeed += speed;
                _speedSampleCount++;
                return _totalSpeed / _speedSampleCount;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            _procedureOwner = procedureOwner;

            Log.Info("开始下载更新文件！");

            LauncherMgr.ShowUI<LoadUpdateUI>(ScriptLocalization.LC_LAUNCHER_StartDownload);

            BeginDownload().Forget();
        }

        private async UniTaskVoid BeginDownload()
        {
            var downloader = _resourceModule.Downloader;

            // 注册下载回调
            downloader.DownloadErrorCallback = OnDownloadErrorCallback;
            downloader.DownloadUpdateCallback = OnDownloadProgressCallback;
            downloader.BeginDownload();
            await downloader;

            // 检测下载结果
            if (downloader.Status != EOperationStatus.Succeed)
                return;

            ChangeState<ProcedureDownloadOver>(_procedureOwner);
        }

        private void OnDownloadErrorCallback(DownloadErrorData downloadErrorData)
        {
            LauncherMgr.ShowMessageBox(ScriptLocalization.LC_LAUNCHER_Title_Error, Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_DownloadFileFailed, downloadErrorData.FileName),
                () => { ChangeState<ProcedureCreateDownloader>(_procedureOwner); }, UnityEngine.Application.Quit);
        }

        private void OnDownloadProgressCallback(DownloadUpdateData downloadUpdateData)
        {
            string currentSizeMb = (downloadUpdateData.CurrentDownloadBytes / 1048576f).ToString("f1");
            string totalSizeMb = (downloadUpdateData.TotalDownloadBytes / 1048576f).ToString("f1");
            float progressPercentage = _resourceModule.Downloader.Progress * 100;
            string speed = Utility.FileUtils.GetLengthString((int)CurrentSpeed);

            string line1 = Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_UpdatingProgress,
                downloadUpdateData.CurrentDownloadCount, downloadUpdateData.TotalDownloadCount, progressPercentage);
            string line2 = Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_UpdatedSize, currentSizeMb, totalSizeMb);
            string line3 = Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_CurrentSpeed, speed,
                GetRemainingTime(downloadUpdateData.TotalDownloadBytes, downloadUpdateData.CurrentDownloadBytes, CurrentSpeed));

            LauncherMgr.RefreshProgress(_resourceModule.Downloader.Progress);
            LauncherMgr.ShowUI<LoadUpdateUI>(Utility.Text.Format(ScriptLocalization.LC_LAUNCHER_DownloadFileDetail, line1, line2, line3));

            Log.Info($"{line1} {line2} {line3}");
        }

        private string GetRemainingTime(long totalBytes, long currentBytes, float speed)
        {
            int needTime = 0;
            if (speed > 0)
            {
                needTime = (int)((totalBytes - currentBytes) / speed);
            }

            TimeSpan ts = new TimeSpan(0, 0, needTime);
            return ts.ToString(@"mm\:ss");
        }
    }
}