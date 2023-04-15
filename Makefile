-- db-scaffold :
	cd API && dotnet dotnet-ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models --data-annotations
-- test :
	dotnet test --logger "console;verbosity=detailed"