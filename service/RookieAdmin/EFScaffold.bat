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


dotnet ef dbcontext scaffold "Server=.\sqlexpress;Database=Rookiedb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models/Entity --context RookieAdminDbContext -f ^
-t SysMenu ^
-t SysPermission ^
-t SysRole ^
-t SysUser ^
-t SysUserRole

set /p temp="Enter to End" 