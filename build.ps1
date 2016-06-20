tools\nuget.exe restore src\Hermes\Hermes.sln

&'C:\Program Files (x86)\MSBuild\14.0\bin\msbuild' src\Hermes\Hermes.sln

src\Hermes\packages\roundhouse.0.8.6\bin\rh.exe --server `(localdb`)\v11.0 --database Hermes --versionfile=src\Hermes\Entities\bin\Debug\Entities.dll --files src\Hermes\db
