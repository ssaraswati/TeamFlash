# TeamFlash - Flash Only

Conversion of TeamFlash to run as a service and only flash the light

It's tested with the [Delcom 904003](http://www.delcomproducts.com/productdetails.asp?productnum=904003) and [Delcom 804003](http://www.delcomproducts.com/productdetails.asp?productnum=804003) (old generation).


# Install
Clone and build the project
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe TeamFlash.exe

open services.msc and set start/stop options as needed
# Uninstall
sc delete teamflash


## Code

…is moderately average. We know. We hacked it together on a client site eons ago, then published it when we wanted to re-use it elsewhere. Don't hate us: send a pull request instead.

We also know that there are other projects that do the same thing, like [SouthsideSoftware/BuildLight](https://github.com/SouthsideSoftware/BuildLight). We wrote this a while ago, and wanted to publish it anyway.
