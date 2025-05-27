# EF Core 9 Migration Issue Reproduction

This repository aims to reproduces a migration validation issue in Entity Framework Core 9.0.5 where running initial migrations fails when the migration history contains operations for tables that have been properly removed from the current model.

Unfortunately, although the issue remains a problem in our actual application, this issue does not occur in this test program...

## Issue Description

When running migrations on a fresh database, I'd expect EF Core 9.0.5 to fail with:
```
The given key '(TestToRemove, dbo)' was not present in the dictionary.
```

and the following callstack:
```
   at System.ThrowHelper.ThrowKeyNotFoundException[T](T key)
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at Microsoft.EntityFrameworkCore.Migrations.SqlServerMigrationsSqlGenerator.RewriteOperations(IReadOnlyList`1 migrationOperations, IModel model, MigrationsSqlGenerationOptions options)
   at Microsoft.EntityFrameworkCore.Migrations.SqlServerMigrationsSqlGenerator.Generate(IReadOnlyList`1 operations, IModel model, MigrationsSqlGenerationOptions options)
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.GenerateUpSql(Migration migration, MigrationsSqlGenerationOptions options)
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<>c__DisplayClass25_2.<GetMigrationCommandLists>b__2()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<MigrateImplementationAsync>d__23.MoveNext()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<MigrateImplementationAsync>d__23.MoveNext()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<>c.<<MigrateAsync>b__22_1>d.MoveNext()
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<MigrateAsync>d__22.MoveNext()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<MigrateAsync>d__22.MoveNext()
   at Pca.IdentityService.Repository.DatabaseDetector.<Migrate>d__8.MoveNext() in
   ...
```

This should occur even though:
1. The `TestToRemove` table was properly removed via a `DropTable` migration
2. The entity has been completely removed from the current DbContext model
3. This scenario worked correctly in EF Core 8.x

Unfortunately, although the issue remains a problem in our actual application, this issue does not occur in this test program...

## Related Issue

This reproduction is for: https://github.com/dotnet/efcore/issues/35162

## Notes

- The issue only occurs when running migrations on a fresh database
- If migrations have been applied previously, no error occurs
- The `TestToRemove` entity is kept in the repository for reference but is not included in the current `DbContext` model
