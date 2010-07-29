@echo off
cls
build\tools\nant\nant.exe -buildfile:build\project.build %* -nologo
@echo %time%
