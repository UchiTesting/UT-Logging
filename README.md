UT-Logging
==========

Experimenting and discovering logging with NLog and ASP .NET Core.


## Did add Some stuff to log to Seq

> ⚠ This is the most basic configuration.  
> For more advanced setup please visit [instructions @DockerHub](<https://hub.docker.com/r/datalust/seq>).


Be sure to remove the intentional spaces from the command left in  an *nlog.config* file comment.

Or copy it from there:

`docker run --name seq --rm -e ACCEPT_EULA=Y -v c:\temp:/data -p 5341:80 datalust/seq:latest`

![image](https://github.com/UchiTesting/UT-Logging/assets/56003633/bac3001c-d857-4af2-be1d-12686a612cb5)

Also tried a basic query.

> rndNb is the name of the structured log message variable for the random number represented in pink.  
> The date is also such variable and with a ditinguished colour.  
> Notice the tooltip (though mouse pointer is not visible).

![image](https://github.com/UchiTesting/UT-Logging/assets/56003633/3bebbb5f-3467-4674-8448-4c6d8d459236)

We can also expand a log message to check detailed information.

This is the power to structured logging.

![image](https://github.com/UchiTesting/UT-Logging/assets/56003633/a84b3720-290c-4882-848b-6c9f73ac4a94)

