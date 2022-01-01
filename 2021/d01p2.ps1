[int[]] $measurements = Get-Content -Path ./day1input.txt

[int] $numLargerMeasurements = 0;
for ($i = 1; $i -lt $measurements.Count - 2; $i++)
{
    [int] $a = $measurements[$i-1] + $measurements[$i  ] + $measurements[$i+1]
    [int] $b = $measurements[$i  ] + $measurements[$i+1] + $measurements[$i+2]
    if ($b -gt $a)
    {
        $numLargerMeasurements++;
    }
}

Write-Host "Number of measurements larger than the previous measurement: $numLargerMeasurements"