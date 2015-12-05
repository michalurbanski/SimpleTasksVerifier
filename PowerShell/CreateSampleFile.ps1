# Script creates file in AppData catalog specific to the application


write-host $env:APPDATA
$applicationName = "SimpleTasksVerifier"
$fileName = "SampleDataFile.txt"

$path = "$env:APPDATA\$applicationName\"

if(Test-Path $path\$fileName){
    write-host "File $fileName is already created"
}
else{
    write-host "Creating file $fileName..."
    New-Item -Path $env:APPDATA -Name $applicationName -ItemType Directory
    New-Item -Path $path -Name $fileName -ItemType File 
}