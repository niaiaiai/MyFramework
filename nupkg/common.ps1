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
    #"MyFramework/src/MyAspNetCore",
    #"MyFramework/src/MyAuthorization",
    #"MyFramework/src/MyCore",
    "MyFramework/src/MyEntity",
    "MyFramework/src/MyEntityFrameworkCore",
    "MyFramework/src/MyRepositories",
    "MyFramework/src/MyServices",
    "MyFramework/src/Utils"
)
