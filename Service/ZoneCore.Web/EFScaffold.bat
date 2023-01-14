@ECHO OFF

FOR /F %%I IN ('dotnet ef --version') DO SET _efversion=%%I
echo %_efversion%

if %_efversion% == "" (
    echo "Check EF Core"
    exit /b 0
) 

rem --SQL generator--

rem SELECT '-t ' + TABLE_NAME + ' ^'
rem FROM INFORMATION_SCHEMA.TABLES 
rem Order by TABLE_NAME


dotnet ef dbcontext scaffold "Server=.\sqlexpress;Database=Zonedb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entity --context SystemDbContext -f --project ..\ZoneCore.Models ^
-t SysMenu ^
-t SysRole ^
-t SysRoleMenu ^
-t SysUser ^
-t SysUserRole

set /p temp="Enter to End" 