using System;
using Cysharp.Threading.Tasks;
using Launcher;
using TEngine;

namespace Procedure
{
    /// <summary>
    /// 7. 开始游戏， 关闭启动器
    /// </summary>
    public class ProcedureStartGame : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            StartGame().Forget();
        }

        private async UniTaskVoid StartGame()
        {
            await UniTask.Yield();
            LauncherMgr.HideAll();
        }
    }
}