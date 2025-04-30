// using UnityEngine.Rendering;
using ProcedureOwner = TEngine.IFsm<TEngine.IProcedureModule>;

namespace Procedure
{
    /// <summary>
    /// 2. 流程 => 闪屏。 => InitPackage
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        public override bool UseNativeDialog => true;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // SplashScreen.Begin();
            // SplashScreen.Draw();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            // if (!SplashScreen.isFinished)
            //     return;

            //初始化资源包
            ChangeState<ProcedureInitPackage>(procedureOwner);
        }
    }
}
