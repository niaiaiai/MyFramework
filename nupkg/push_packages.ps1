. ".\common.ps1"

$apiKey = $args[0]
$version = $args[1]

# Get the version
#[xml]$commonPropsXml = Get-Content (Join-Path $rootFolder "common.props")
#$version = $commonPropsXml.Project.PropertyGroup.Version

# Publish all packages
foreach($project in $projects) {
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    & dotnet nuget push ($projectName + "." + $version + ".nupkg") -s http://studydemo.online:13564/v3/index.json --api-key "$apiKey"
    Remove-Item ($projectName + "." + $version + ".nupkg")
}

# Go back to the pack folder
Set-Location $packFolder
