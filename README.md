Ethernet Link Config v.5+
CallerID.com
---------------------------------------

	- Updated visual GUI
	- Removed some coding so Windows Defender does not false flag program
	
---------------------------------------

	- Duplicates work by adding reception to buffer then after 4 seconds removing it. This gives
	the Caller ID unit long enough to send all duplicates and then resets ELConfig for next call.
	
	- Help with handing duplicates can be found by searching for: "DUPLICATES CODING START"
	and "DUPLICATES CODING END" within this project on the Forms\FrmMain.cs

