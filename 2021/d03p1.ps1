[string[]] $numbers = Get-Content -Path ./day3input.txt

[string] $gamma = ""
[string] $epsilon = ""

for ($i = 0; $i -lt $numbers[0].Length; $i++)
{
    [int] $sum = 0
    foreach ($number in $numbers)
    {
        $num = $number[$i].ToString()
        $sum += [Convert]::ToInt32($num)
    }

    if ($sum -gt $numbers.Count - $sum)
    {
        $gamma += "1"
        $epsilon += "0"
    }
    else
    {
        $gamma += "0"
        $epsilon += "1"
    }
}

[int] $g = [Convert]::ToInt32($gamma, 2)
[int] $e = [Convert]::ToInt32($epsilon, 2)
Write-Host "Gamma: $g ($gamma)"
Write-Host "Epsilon: $($e) ($epsilon)"
Write-Host "Multiplied Total: $($g * $e)"