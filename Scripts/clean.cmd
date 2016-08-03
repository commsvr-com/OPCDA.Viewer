echo off
rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$


rem DEL [/P] [/F] [/S] [/Q] [/A[[:]attributes]] names
rem   names         Specifies a list of one or more files or directories.
rem                 Wildcards may be used to delete multiple files. If a
rem                 directory is specified, all files within the directory
rem                 will be deleted.
rem 
rem   /P            Prompts for confirmation before deleting each file.
rem   /F            Force deleting of read-only files.
rem   /S            Delete specified files from all subdirectories.
rem   /Q            Quiet mode, do not ask if ok to delete on global wildcard
rem   /A            Selects files to delete based on attributes
rem   attributes    R  Read-only files            S  System files
rem                 H  Hidden files               A  Files ready for archiving
rem                 -  Prefix meaning not
REM RMDIR [/S] [/Q] [drive:]path
REM RD [/S] [/Q] [drive:]path

REM     /S      Removes all directories and files in the specified directory
REM             in addition to the directory itself.  Used to remove a directory
REM             tree.

REM     /Q      Quiet mode, do not ask if ok to remove a directory tree with /S
rem all cleanup should be performed in the following directories:
rem EX01-OPCFoundation_NETApi
rem PR24-Biblioteka
rem PR30-OPCViever
echo "$URL$"
cd ..\..\

RD /S /Q .\PR30-OPCViever\bin 
RD /S /Q .\PR30-OPCViever\Deliverables 
RD /S /Q .\PR30-OPCViever\CAS.Lib.UnitTests\bin 
RD /S /Q .\PR30-OPCViever\CAS.Lib.UnitTests\obj 
RD /S /Q .\PR30-OPCViever\CAS.OPCClientControlsLib\bin 
RD /S /Q .\PR30-OPCViever\CAS.OPCClientControlsLib\obj 
RD /S /Q .\PR30-OPCViever\AddressSpace\bin 
RD /S /Q .\PR30-OPCViever\AddressSpace\obj 
RD /S /Q .\PR30-OPCViever\MainGUI\bin 
RD /S /Q .\PR30-OPCViever\MainGUI\obj 
RD /S /Q .\PR30-OPCViever\Scripts\bin 
RD /S /Q .\PR30-OPCViever\Scripts\obj 
rem deleting project user files
del /F /S /Q /A:H .\PR30-OPCViever\*.suo
del /F /S /Q /A:H .\PR30-OPCViever\*.user
rem deleting objects
del /F /S /Q  .\PR30-OPCViever\*.obj
rem deleting intellisence
del /F /S /Q  .\PR30-OPCViever\*.ncb
rem deleting debuger informations
del /F /S /Q  .\PR30-OPCViever\*.pdb
rem deletind desktop.ini
del /F /S /Q /A:H .\PR30-OPCViever\*.ini

if /I "%1" NEQ "local" (
echo cleanup
echo $URL$
cd .\PR24-Biblioteka\Scripts
call clean.cmd 
cd ..\..
echo $URL$
cd .\EX01-OPCFoundation_NETApi\Scripts
call clean.cmd 
cd ..\..
)
rem returning to base directory
cd .\PR30-OPCViever\Scripts

rem del /F /S /Q  .\EX01-OPCFoundation_NETApi\*.obj

echo on
