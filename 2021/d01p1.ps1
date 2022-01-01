[int[]] $measurements = Get-Content -Path ./day1input.txt

[int] $numLargerMeasurements = 0;
for ($i = 1; $i -lt $measurements.Count; $i++)
{
    if ($measurements[$i] -gt $measurements[$i-1])
    {
        $numLargerMeasurements++;
    }
}

Write-Host "Number of measurements larger than the previous measurement: $numLargerMeasurements"