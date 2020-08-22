Deployment SDK : netcoreapp2.2 or netcoreapp2.2.300

for updating Database tables, First of all add or delete columns at table and run below command at package Manager Console

Scaffold-DbContext "Data Source=DESKTOP-KRG2RAL\SQLEXPRESS;Initial Catalog=TravelOlive;Persist Security Info=True;User ID=sa;Password=1234;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -force


Scaffold-DbContext "Data Source=34.93.129.68;Initial Catalog=TravelOlive;Trusted_Connection=false;User ID=OliveTravel;Password=Olive@786;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -force


Scaffold-DbContext "Data Source=GMCSCO-SERVER-8\SQLEXPRESS;Initial Catalog=TravelOlive;Persist Security Info=True;User ID=sa;Password=pawan@123;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -force
