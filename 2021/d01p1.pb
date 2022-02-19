EnableExplicit

Define file = ReadFile(#PB_Any, "day1input.txt")

If IsFile(file)
  NewList measurements.i()
  While Eof(file) = 0
    AddElement(measurements())
    Define number.s = ReadString(file)
    measurements() = Val(number)
  Wend
  CloseFile(file)
EndIf

Define numLargerMeasurements.i = 0
Define i
For i = 1 To ListSize(measurements()) - 1
  SelectElement(measurements(), i)
  Define current.i = measurements()
  
  SelectElement(measurements(), i - 1)
  Define previous.i = measurements()
  
  If current > previous
    numLargerMeasurements = numLargerMeasurements + 1
  EndIf
Next

OpenConsole("Advent of Code Day 1 Puzzle 1")
PrintN("foo")
PrintN(Str(numLargerMeasurements))
Delay(5000)
FreeList(measurements())
; IDE Options = PureBasic 5.73 LTS (Linux - x64)
; ExecutableFormat = Console
; CursorPosition = 31
; EnableXP
; Executable = d01p1.bin