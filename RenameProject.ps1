$defaultNamespace = "Coalesce.Starter";
$defaultDatabase = "CoalesceStarterDb";
$defaultConnection = "Server=(localdb)\\MSSQLLocalDB;Database=$defaultDatabase;Trusted_Connection=True;MultipleActiveResultSets=True;";

Write-Host ""
Write-Host "This script helps you rename the $defaultNamespace project to fit your application."
Write-Host "No changes will be made until you confirm all your inputs."
Write-Host "Please close Visual Studio before running this script." -ForegroundColor Green
Write-Host ""

Write-Host "The default root namespace is " -NoNewline
Write-Host -ForegroundColor Yellow "$defaultNamespace."
$rootNamespace = Read-Host -Prompt "Enter the desired root namespace"

if (-not $rootNamespace){
	throw "Namespace must not be empty"
}

$nsParts = $rootNamespace.Split(".")
$dbName = "$($nsParts[$nsParts.Length - 1])Db"


Write-Host "The default connection string is " -NoNewline
Write-Host -ForegroundColor Yellow $defaultConnection
Write-Host "Enter the desired default connection string. Leave blank to set the Database to " -NoNewline
Write-Host $dbName -ForegroundColor Yellow -NoNewline
Write-Host ": " -NoNewline
$connectionString = Read-Host


if (-not $connectionString){
	$connectionString = $defaultConnection.Replace($defaultDatabase, $dbName)
}


Write-Host ""

Write-Host "Please confirm your input: " -ForegroundColor Green
Write-Host "   Root Namespace: " -NoNewline
Write-Host $rootNamespace -ForegroundColor Yellow
Write-Host "Connection String: " -NoNewline
Write-Host $connectionString -ForegroundColor Yellow

Write-Host ""

Write-Host "Please close Visual Studio before continuing." -ForegroundColor Green
$confirmation = Read-Host "Are you sure you want to continue and rename this project? (y/n)"
if ($confirmation -eq 'y') {
	
	Write-Host ""

    $vs = "$PSScriptRoot\.vs"
    if (Test-Path $vs){
	    Write-Host "Deleting $vs"
        Remove-Item $vs -Recurse -Force
    }


	$files = Get-ChildItem $PSScriptRoot -File -Recurse |
		?{ $_.fullname -ne $PSCommandPath } |
		?{ $_.fullname -notmatch "\\bin\\?" } |
		?{ $_.fullname -notmatch "\\obj\\?" } |
		?{ $_.fullname -notmatch "\\packages\\?" } |
		?{ $_.fullname -notmatch "\\submodules\\?" } |
		?{ $_.fullname -notmatch "\\node_modules\\?" }
	foreach ($file in $files)
	{
		$content = Get-Content $file.FullName -Raw
		if ($content){
			$newContent = $content -replace $defaultConnection, $connectionString
			$newContent = $newContent -replace $defaultNamespace, $rootNamespace

			if ($content -ne $newContent) {
				# Set-Content throws errors a lot of the time.
				# Set-Content $file.FullName -Value $newContent
				Write-Host "Replacing text in $($file.FullName)"
				[System.IO.File]::WriteAllText($file.FullName,$newContent)
			}
		}
	}


	$files = Get-ChildItem $PSScriptRoot -Recurse |
		?{ $_.fullname -ne $PSCommandPath } |
		sort FullName -Descending
	foreach ($file in $files)
	{
		if ($file.Name.Contains($defaultNamespace)){
			Write-Host "Renaming $($file.FullName)"
			$file | Rename-Item -NewName $file.Name.Replace($defaultNamespace, $rootNamespace)
		}
	}
}
