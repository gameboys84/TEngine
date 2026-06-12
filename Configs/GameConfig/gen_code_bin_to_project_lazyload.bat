Cd /d %~dp0
echo %CD%

set WORKSPACE=../..
set LUBAN_DLL=%WORKSPACE%\Tools\Luban\bin\Luban.dll
set CONF_ROOT=.
set DATA_OUTPATH=%WORKSPACE%/UnityProject/Assets/AssetBundle/AutoGen/GameConfig/
set CODE_OUTPATH=%WORKSPACE%/UnityProject/Assets/Scripts/Runtime/Proto/GameConfig/

copy /y "%CONF_ROOT%\CustomTemplate\ConfigSystem.cs" "%WORKSPACE%/UnityProject/Assets/Scripts/Runtime/Proto/ConfigSystem.cs"
copy /y "%CONF_ROOT%\CustomTemplate\ExternalTypeUtil.cs" "%WORKSPACE%/UnityProject/Assets/Scripts/Runtime/Proto/ExternalTypeUtil.cs"

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin^
    --conf %CONF_ROOT%\luban.conf ^
    --customTemplateDir %CONF_ROOT%\CustomTemplate\CustomTemplate_Client_LazyLoad ^
    -x code.lineEnding=crlf ^
    -x outputCodeDir=%CODE_OUTPATH% ^
    -x outputDataDir=%DATA_OUTPATH% 
if not defined AI_MODE pause

