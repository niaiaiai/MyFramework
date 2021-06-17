# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    "MyFramework"
)

# List of projects
$projects = (

    # framework
    "src/MyAspNetCore",
    #"src/MyAuthorization",
    "src/MyCore"
    #"src/MyEntity",
    #"src/MyEntityFrameworkCore",
    #"src/MyRepositories",
    #"src/MyServices",
    #"src/Utils"
)
