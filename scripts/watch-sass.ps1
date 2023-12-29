$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")

# check sass command exists
if (! (Get-Command sass -ErrorAction SilentlyContinue)) {
	Write-Host "sass command not found"
	Write-Host "Please install sass manually."
	Write-Host "If you use winget package manager, use 'winget install Sass.DartSass' to install."
	Write-Host "Otherwise, use 'https://github.com/sass/dart-sass/releases/' to install."
	exit
}

# get watch directory
$currentDirName = (Get-Item -Path ".\" | Select-Object -ExpandProperty Name)
if ($currentDirName -eq "scripts") {
    $watchDir = Join-Path -Path (Get-Location) -ChildPath "..\src"
} else {
    $watchDir = Join-Path -Path (Get-Location) -ChildPath "src"
}

if (-not (Test-Path -Path $watchDir -PathType Container)) {
	Write-Host "Directory 'src' is not found"
    exit
}

# compile sass
# --watch will not compile scss until file changes, so run compile first before watch
sass --style=compressed --no-source-map .:. $watchDir.FullName

# watch sass
sass --watch --style=compressed --no-source-map .:. $watchDir.FullName
