[string[]] $steps = Get-Content -Path ./day2input.txt

[int] $position = 0
[int] $depth = 0

foreach ($step in $steps)
{
    [string] $command = $step.Split(" ")[0]
    [int] $value = [int] $step.Split(" ")[1]

    if ($command -eq "forward") { $position += $value }
    if ($command -eq "down")    { $depth += $value    }
    if ($command -eq "up")      { $depth -= $value    }
}

Write-Host "Final position: $position"
Write-Host "Final depth: $depth"
Write-Host "Multiplied result: $($position * $depth)"