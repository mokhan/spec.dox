@echo off
cls
tools\nant\nant.exe -buildfile:project.build %* -nologo
@echo %time%
