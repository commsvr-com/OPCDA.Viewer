rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$
if "%1%"=="" goto ERROR
svn mkdir svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1  -m "created new tag OPCViewer %1 (release folder)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR30-OPCViever svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1/PR30-OPCViever -m "created new OPCViewer tag %1 (project PR30-OPCViever)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR24-Biblioteka svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1/PR24-Biblioteka -m "created new OPCViewer tag %1 (project PR24-Biblioteka)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/ImageLibrary svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1/ImageLibrary -m "created new OPCViewer tag %1 (project ImageLibrary)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/PR39-CommonResources svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1/PR39-CommonResources -m "created new OPCViewer tag %1 (project PR39-CommonResources)"
svn copy svn://svnserver.hq.cas.com.pl/VS/trunk/CommonBinaries svn://svnserver.hq.cas.com.pl/VS/tags/OPCViewer/%1/CommonBinaries -m "created new OPCViewer tag %1 (project CommonBinaries)"

goto EXIT
:ERROR
echo Parametr must be set
:EXIT
