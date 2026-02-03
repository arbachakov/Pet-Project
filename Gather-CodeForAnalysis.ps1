# Save as: CodeSnapshot.ps1
# Совместимый сборщик кода для анализа.

$ProjectPath = $PSScriptRoot
$OutputFile = Join-Path $ProjectPath "CODE_SNAPSHOT.txt"

# Полная перезапись файла
"=== C# ПРОЕКТ: ПОЛНЫЙ СНИМОК КОДА ===" | Out-File -FilePath $OutputFile -Force
"Сгенерировано: $(Get-Date -Format 'yyyy-MM-dd HH:mm')" | Add-Content -Path $OutputFile
"Путь: $ProjectPath" | Add-Content -Path $OutputFile
"" | Add-Content -Path $OutputFile

# СТРУКТУРА ПАПОК
"СТРУКТУРА ПАПОК (с .cs файлами):" | Add-Content -Path $OutputFile
"" | Add-Content -Path $OutputFile

function Write-Structure {
    param([string]$Path, [string]$Indent = "")
    
    $items = Get-ChildItem -Path $Path -Force | 
             Where-Object { $_.Name -notmatch '^(bin|obj|\.git|\.vs|packages)$' } |
             Sort-Object { $_.PSIsContainer -eq $false }
    
    $itemCount = $items.Count
    for ($i = 0; $i -lt $itemCount; $i++) {
        $item = $items[$i]
        $isLast = ($i -eq $itemCount - 1)
        
        if ($item.PSIsContainer) {
            # Проверяем, есть ли в папке .cs файлы
            $hasCsFiles = (Get-ChildItem $item.FullName -Recurse -Filter *.cs -File -ErrorAction SilentlyContinue).Count -gt 0
            if (-not $hasCsFiles) { continue }
            
            # Определяем префикс для папки
            if ($isLast) {
                "$Indent└── $($item.Name)/" | Add-Content -Path $OutputFile
            } else {
                "$Indent├── $($item.Name)/" | Add-Content -Path $OutputFile
            }
            
            # Определяем отступ для следующего уровня
            if ($isLast) {
                $newIndent = $Indent + "    "
            } else {
                $newIndent = $Indent + "│   "
            }
            
            Write-Structure -Path $item.FullName -Indent $newIndent
        }
        elseif ($item.Extension -eq '.cs') {
            if ($isLast) {
                "$Indent└── $($item.Name)" | Add-Content -Path $OutputFile
            } else {
                "$Indent├── $($item.Name)" | Add-Content -Path $OutputFile
            }
        }
    }
}

Write-Structure -Path $ProjectPath
"" | Add-Content -Path $OutputFile

# КОД БЕЗ ЛИШНИХ МЕТАДАННЫХ
"================================================================================
СОДЕРЖАНИЕ ФАЙЛОВ:
================================================================================" | Add-Content -Path $OutputFile
"" | Add-Content -Path $OutputFile

$allCsFiles = Get-ChildItem -Path $ProjectPath -Recurse -Filter *.cs -File |
              Where-Object { $_.FullName -notmatch '\\bin\\|\\obj\\' } |
              Sort-Object DirectoryName, Name

$fileCount = 0
foreach ($file in $allCsFiles) {
    $fileCount++
    $relativePath = $file.FullName.Substring($ProjectPath.Length).TrimStart('\')
    
    "─── ФАЙЛ: $relativePath ───" | Add-Content -Path $OutputFile
    
    # Чистый код, как есть
    Get-Content -Path $file.FullName -Raw | Add-Content -Path $OutputFile
    
    # Минимальный разделитель между файлами
    "" | Add-Content -Path $OutputFile
    "// Конец файла: $($file.Name)" | Add-Content -Path $OutputFile
    "" | Add-Content -Path $OutputFile
}

# Итог
"================================================================================
ИТОГО: обработано $fileCount .cs файлов.
================================================================================" | Add-Content -Path $OutputFile

Write-Host "Снимок создан: $OutputFile" -ForegroundColor Green
Write-Host "Файлов обработано: $fileCount" -ForegroundColor Cyan