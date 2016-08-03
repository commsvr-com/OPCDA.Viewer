#####################################################################
# OPC Viewer release notes
#
# $LastChangedDate$
# $Rev$
# $LastChangedBy$
# $URL$
# $Id$ 
#
#####################################################################

############################################
###OPC Viewer rel_3_10_02                ###
############################################
      
New OPC Viewer 3.10.02 is available.
This is only bugfix release. The main changes are listed below:
- Resolved issue with license installation ("wrong hardware key");
- Resolved issue with displaying information about license failure.

Nowa wersja oprogramowania OPC Viewer 3.10.02 jest ju¿ dostêpna.
Ten release zawiera tylko drobne poprawki. Do najwa¿niejszych zmian i nowoœci zaliczyæ mo¿na:
- Rozwi¹zano problem z instalacj¹ licencji (i informacj¹ o z³ym kluczu sprzêtowym);
- Rozwi¹zano problem z wyœwietlaniem informacji o problemie z licencj¹.


This release includes:
    * 4.00.02-CMCORE Bravo Kilo
    * 2.0.108-NETAPI - Alpha Echo 
    * 3.70.08-DPP - Bravo Mike
    * 4.00.02-CLIB Bravo Lima
    * 1.00.04-CRSC-Bravo Golf



############################################
###OPC Viewer rel_3_10_00                ###
############################################
      
New OPC Viewer 3.10.00 is available.
The main changes are listed below:
- Some improvements to the user interface.
- Improved licensing management.
- Improved support for Windows Vista, 7 and 2008.
- New location (based on ALLUSERSPROFILE) of configuration and log files (see product manual for details).
- Some issues during installation / uninstallation are fixed.
- Support of x64 operating systems(OPC Viewer works as 32-bit application on x64 OS)
- Small bugfixes and improvements.

Nowa wersja oprogramowania OPC Viewer 3.10.00 jest ju¿ dostêpna.
Do najwa¿niejszych zmian i nowoœci zaliczyæ mo¿na:
- Drobne poprawki interfejsu u¿ytkownika.
- Ulepszono sposób zarz¹dzania licencjami w oprogramowaniu.
- Poprawiono wsparcie dla systemów operacyjnych jak Windows Vista, 7 i 2008.
- Pliki konfiguracyjne i logów umieszczano w nowej lokalizacji (bazuj¹cej na ALLUSERSPROFILE) (szczegó³y opisano w dokumentacji do produktu).
- Wprowadzono poprawki rozwi¹zuj¹ce b³êdy mog¹ce wyst¹piæ podczas instalacji, b¹dŸ dezinstalacji.
- Dodano wsparcie dla systemów x64 (OPC Viewer pracuje jako aplikacja 32-bitowa w systemie x64)
- Drobne poprawki i ulepszenia.


This release includes:
    * 4.00.00-CMCORE Alpha Victor
    * 2.0.108 - NETAPI - Alpha Echo 
    * 3.70.06-DPP - Alpha Yankee
    * 4.00.00-CLIB Alpha Whiskey
    * 1.00.01-CRSC    

OPV-2639	Enter unlock code window don't work when Alt+K is pressed.        
OPV-1955	Release 3.10.00-OPV - bugfix
OPV-1956	There is error while reinstalling the OPC Viewer
OPV-1996	Problem with saving of the addres space dictionary.
OPV-2574	StackOverflow exception after double click on Save icon
OPV-1954	RSS openg main page
OPV-1953	Unhandled exception while openning RSS
OPV-2211	Not handled exception while sorting the table
OPV-2261	Missing License.rtf file
OPV-2345	Changes referenced to Licensing
OPV-2324	OPCV: Manifest genearation during install
OPV-2467	Split AboutForm and LicenseForm
OPV-570	    Remove ImagesResources.resx from the CL.MainGUI project
OPV-2441	Implement software unlocking codes
OPV-2447	Implement listener for License warning
OPV-2425	Improve location of the logs
OPV-2615	Save as dialog should have initial directory set to current AppliCationData folder
OPV-2565	Add namespace in the AssemblyVersionInfo
OPV-2357	Modify setup to install content files as CommonApplicationData
OPV-998	    Banner for the installer


############################################
###OPC Viewer rel_3_00_02 (codename: IOP)###
############################################
The main changes and new functionalities are listed below:
* Tested for Compliance and Interoperability at OPC Interoperability Workshop (2009) in Nuremberg, Germany
* OPC Viewer is now more informative; diagnostic information is stored in the log file and displayed on the Debug tab. The Debug tab displays information about the connection status and errors or warning information if any
* Sorting of the items in the subscription window is now available
* Many improvements and minor bug fixes

Do najwa¿niejszych zmian i nowoœci zaliczyæ mo¿na:
* Zosta³a przetestowana pod k¹tem kompatybilnoœci i wspó³dzia³ania z innymi produktami podczas OPC Interoperability Workshop (2009) w Norymberdze, Niemcy
* Udostêpnia u¿ytkownikowi wiêcej informacji. Informacje diagnostyczne mog¹ byæ przechowywane w pliku logów oraz wyœwietlane w zak³adce "Debug". Zak³adka "Debug" wyœwietla informacje o stanie po³¹czenia oraz b³êdy i ostrze¿enia, je¿eli jakieœ wyst¹pi¹
* Sortowanie elementów w oknie subskrypcji jest dostêpne
* Wiele ulepszeñ i drobne poprawki mniej znacz¹cych b³êdów


OPV-1876  	OPC V after instalation from click once display "URI Format Not supported"  
OPV-1002 	Click Once icone in Add/Remove programs 
OPV-1781 	Change CAS OPC Viewer online support shortcut in start menu. 
OPV-1847 	Null reference while importing properties 
OPV-1785 	Right pane refresh need to be changed. 
OPV-873 	Loading session configuration problem 
OPV-744 	Subscription option after disconnecting have default values. 
OPV-802 	Subscription read asynchronously stop key 
OPV-495 	OPC Viewer - hangs sometimes during browsing the Server 
OPV-544 	I am not shure about role of the Specification box 
OPV-567 	Preferred specification problem 
OPV-569 	Configuration problem with the computer name 
OPV-703 	BrowseTreeCtrl: select context menu item is always active 
OPV-966 	Keep alive causes manhandled exception 
OPV-1787 	Unable to set KeepAlive on created subscription. 
OPV-1863 	When the state of the item is failed on the OPC environment tree the icon i wrong (from transation) 
OPV-1042 	Tag can be inactive on the tree and active in OPC 
OPV-622 	Edit subscription - cannot switch off keepalive 
OPV-529 	When client receive the empty list of tag in the AddItem answer those items appear in the list and we are able to read them. 
OPV-525 	Add Items displays &quot;Object Null Reference&quot; 
OPV-526 	When server returns UNSUPPORTED UPDATE RATE at least message should appear 
OPV-497 	GetProperties is not displaying error when fail 
OPV-500 	Find out how many handles for the subscription are in the OPCViewer 
OPV-1843 	OPC Viewer improvements (disconnect during app close, message box debbug stop as option) 
OPV-1870 	OPCV does not indicate when async write fails 
OPV-561 	Improve details window while browsing adres space 
OPV-571 	Connect strip while showing Select server dialog change the Mouse pointer 
OPV-664 	Error Handling: AddItems some items can return error. 
OPV-1849 	Modified ignore list 
OPV-1872 	OPC V stores the whole configuration scheme during save 
OPV-877 	Cleanup names of assemblies and project. 
OPV-1674 	OPC Core Components should be added to prerequisites 
OPV-1841 	Debug tab should work as trace listener 
OPV-1842 	CL.OPCClientControlsLib should log some information 


############################################################################
###OPC Viewer rel_2_60_02 (codename: the same as DataPorter Rel. 1.30.00)###
############################################################################

New version 2.60.02 of OPC Viewer is published. The main changes and new functionalities are listed below:
- Added DataPorter service tool strip to menu.
- Added online help references.
- Some minor bugfixes and improvements.


Nowa wersja Oprogramowania OPC Viewer rel. 2.60.02 jest dostêpna. Do najwa¿niejszych zmian zaliczyæ mo¿na:
- Dodano do menu pasek obs³uguj¹cy dzia³anie DataPortera jako serwis.
- Dodano odwo³ania do pomocy online.
- Drobne poprawki i ulepszenia.

Changes based on ITR:
DP-1276	Outputs for DB operation
DP-1306	DB SAve: param is emty when user has not opened properties for DB save operation block
DP-1335	Prepare Help
DP-1580	Cleanup: Remove Transition and use Transaction term instead.
DP-1629	DataPorter as service
DP-1649	DataPorter release 1.30.00
DP-1651	NullReference Exception during adding operation
DP-1670	The view of Operation settings window is not good especially when 120 dpi is set in Windows GUI
