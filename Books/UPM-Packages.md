# Ni UPM 集成

2026-10-27，分支 `tengineni_upm`。原 fork 提交历史保留，框架源码已迁入独立 [TEngineNi_UPM](https://github.com/gameboys84/TEngineNi_UPM) 仓库。本仓库 `FrameworkPackages` 为固定提交子模块，而不是框架副本。

## 获取与运行

```powershell
git clone --recurse-submodules -b tengineni_upm git@github.com:gameboys84/TEngine.git
# 已有检出目录
git submodule update --init FrameworkPackages
```

包指针：`7a71e9eed0511767df01ac12deaf440d6843fa43`。UnityProject 的两个相对路径依赖指向子模块根的 com.ni.tengine 0.6.0、com.ni.gamecore 0.1.0。Unity Editor 版本以 ProjectSettings/ProjectVersion.txt 为准。原依赖下载/凭据要求继续适用；本次没有安装缺失工具或升级依赖。

项目专有入口、网络、事件门面、协议和配置保留在 Assets。通用实现使用 Ni.GameCore / Ni.GameCore.Editor，TEngine.Runtime / TEngine.Editor 名称不变。项目可编辑设置与生成代码保留原目录；脚本 GUID 随迁移保留。不要把包再次复制回 Assets。

## 修改与升级

1. 在 FrameworkPackages 内建立包功能分支，修改、验证并提交到独立 UPM 仓库。
2. 包提交先推送，随后在 Ni 父仓库提交子模块指针。父仓库提交不会自动推送子模块源码。
3. 消费工程通过同一完整 SHA 更新 manifest/lock；需要在两边分别验证使用入口。
4. 新项目安装使用包仓库完整五项 Git 模板或安装脚本，包内不能声明传递 Git URL。

仍可 fetch 原 TEngine 上游并比较其修改，但上游旧 Assets 目录需映射到包内路径，不能直接覆盖复制。先在隔离分支审阅上游增量、项目设置与来源独有文件，合并通用部分到 UPM，验证后更新 Ni 子模块。旧 update-tengine.bat 检测到包目录会在复制/删除/网络步骤前退出。

版本映射为上游 TEngine M.N.P → Ni 0.M.N，当前上游声明 6.0.0 → Ni 0.6.0；GameCore 独立版本 0.1.0。未来独立发版可调整递增策略，不覆盖已发布版本；Git SHA 区分同基线的源码修订。

## 验证与边界

独立包在两个全新 Unity 2022.3.62f2 工程分别完成本地目录、固定 Git 提交导入与编译；包身份、依赖程序集、集合和存档五组功能检查通过。消费工程重新执行 EditMode 3/3、PlayMode 10/10 及完整 .NET 构建，具体记录见包仓库 VALIDATION.md 与消费工程 Doc。

Ni 自身的 CLI/Pipeline 缺失，未取得 Ni 独立 Editor/PlayMode 验收。本轮重新执行 GameCore/GameRuntime 隔离 .NET 集成编译通过，0 错误、7 警告，使用现有 Ni 未变依赖 DLL；不代替完整工程重生成与运行。Ni packages-lock 的共用包依赖记录按 package.json 更新，尚未由 Ni Editor 重新解析确认。IL2CPP、AOT 元数据、泛型、裁剪和设备热更须重新配置并验证；不复用旧热更产物作为本次发布证明。

本轮用户已明确授权拆包、提交与推送；业务 Demo 不回传。审计、备份、差异和临时结果留在消费工程忽略的 Design/reports、Design/local。
