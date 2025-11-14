#To use the script in the future:
#.\transform-categories.ps1 -InputFile "Attributes-detection-ar.txt" -OutputFile "Attributes-detection-transformed-ar.txt"


# Transform Categories Script
# This script transforms the hierarchical category files into flat leaf-node format
# Only leaf nodes (deepest level items) are included in the output

param(
    [string]$InputFile,
    [string]$OutputFile
)

if (-not $InputFile -or -not $OutputFile) {
    Write-Host "Usage: .\transform-categories.ps1 -InputFile <input> -OutputFile <output>"
    Write-Host "Example: .\transform-categories.ps1 -InputFile 'Attributes-detection-ar.txt' -OutputFile 'Attributes-detection-transformed-ar.txt'"
    exit 1
}

# Read input file
$content = Get-Content $InputFile -Encoding UTF8

# Parse all lines with their depth and info
$allLines = @()
foreach ($line in $content) {
    if ([string]::IsNullOrWhiteSpace($line)) { continue }
    
    if ($line -match '^(\t*)([0-9\.]+)\s+(.+?)(\s+--\s+(.+\.cs))?$') {
        $tabs = $matches[1]
        $number = $matches[2]
        $text = $matches[3].Trim()
        $dto = if ($matches[5]) { $matches[5] } else { "CreateAdDto.cs" }
        
        $depth = $tabs.Length
        
        $allLines += [PSCustomObject]@{
            Depth = $depth
            Number = $number
            Text = $text
            Dto = $dto
            OriginalLine = $line
        }
    }
}

# Find leaf nodes (items that don't have children)
$leafNodes = @()
for ($i = 0; $i -lt $allLines.Count; $i++) {
    $current = $allLines[$i]
    $isLeaf = $true
    
    # Check if next line is a child (has greater depth)
    if ($i + 1 -lt $allLines.Count) {
        $next = $allLines[$i + 1]
        if ($next.Depth -gt $current.Depth) {
            $isLeaf = $false
        }
    }
    
    if ($isLeaf) {
        $leafNodes += $current
    }
}

# Build full paths for leaf nodes
$result = @()
$pathStack = @()

foreach ($line in $content) {
    if ([string]::IsNullOrWhiteSpace($line)) { continue }
    
    if ($line -match '^(\t*)([0-9\.]+)\s+(.+?)(\s+--\s+(.+\.cs))?$') {
        $tabs = $matches[1]
        $number = $matches[2]
        $text = $matches[3].Trim()
        $dto = if ($matches[5]) { $matches[5] } else { "CreateAdDto.cs" }
        
        $depth = $tabs.Length
        
        # Adjust path stack to current depth
        if ($depth -lt $pathStack.Count) {
            $pathStack = $pathStack[0..($depth-1)]
        }
        
        if ($depth -eq $pathStack.Count) {
            $pathStack += $text
        } else {
            $pathStack[$depth] = $text
        }
        
        # Check if this is a leaf node
        $isLeaf = $leafNodes | Where-Object { $_.Number -eq $number -and $_.Text -eq $text }
        
        if ($isLeaf) {
            # Build full path
            $path = ($pathStack[0..$depth] | ForEach-Object { 
                $_ -replace '\([^)]*\)', '' -replace '،', '' -replace ',', '' -replace '\s+', '-' -replace '-+', '-' -replace '^-|-$', ''
            }) -join '/'
            
            $result += "$path -- $dto"
        }
    }
}

# Save output file
$result | Out-File $OutputFile -Encoding UTF8

Write-Host "Transformation complete!"
Write-Host "Input file: $InputFile"
Write-Host "Output file: $OutputFile"
Write-Host "Total lines processed: $($allLines.Count)"
Write-Host "Leaf nodes found: $($leafNodes.Count)"
Write-Host "Output lines: $($result.Count)"
