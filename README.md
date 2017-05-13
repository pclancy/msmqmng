# msmqmng
MSMQ Managment Console

Most of information available here also available in the tool itself (type '?' when in command mode) although it is a little less readable.

## Commands

* [List command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#listcommand)
* [Create command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#createcommand)
* [Delete command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#deletecommand)
* [Purge command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#purgecommand)
* [Send command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#sendcommand)
* [Peek command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#peekcommand)
* [Copy command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#copycommand)
* [Export command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#exportcommand)
* [Import command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#importcommand)
* [Load command](http://msmqmngr.codeplex.com/documentation?referringTitle=Documentation&ANCHOR#loadcommand)

#### Notes

When working with private local queues, short version of fully qualified name can be used, for example:<br>

```
Instead of
copy /s .\private$\sourceQueue /d .\private$\destinationQueue, or
send /p .\private$\dQueue /m text

Same commands can run as following
copy /s sourceQueue /d destinationQueue
send /p dQueue /m text
```

<br>

### List command

#### Format

```
list [optional:/h [host]] [optional:/u [domain\username]] [optional:/p [password]]
```

#### Description

Displays list of public queues on the specified host. If host is not provided displays queues for the local machine. If remote host requires different set of credential they can be provided with /u and /p.

#### Examples

```
list
list /h remotehost
list /h remotehost /u workgroup\jdoe /p SuCCeSS$1M!
```

<br>

### Create command

#### Format

```
create /p [path] [optional:/t]
```

#### Description

Creates transactional or non-transactional queue with the specified path.

#### Examples

```
create /p .\private$\MSMQStudioQueue
create /p .\private$\MSMQStudioQueue /t
```

<br>

### Delete command

#### Format

```
delete /p [path]
```

#### Description

Deletes queue referenced by path.

#### Example

```
delete /p .\private$\MSMQStudioQueue
```

<br>

### Purge command

#### Format

```
purge /p [path]
```

#### Description

Removes <b>ALL</b> messages from the queue referenced by path. Does not ask for confirmation.

#### Example

```
purge /p .\private$\MSMQStudioQueue
```

<br>

### Send command

#### Format

```
send /p [path] [opitonal: /c [count]] [/m [message] |  /f [filepath]]
```

#### Description

Sends message in the queue referenced by path. With either text entered after "/m" or read from file referenced by filepath. Double quote escaping is not supported at this time. For file "/f" version of command entire file will be sent.
 If /c parameter was provided message duplicated count times.

#### Examples

```
send /p .\private$\MSMQStudioQueue /m "the text to be sent"
 send /p .\private$\MSMQStudioQueue /f \\folder01\file01.ext
 send /p .\public$\MSMQStudioQueue /c 5 /f X:\folder01\file01.ext
```

<br>

### Peek command

#### Format

```
peek /p [path] [optional: /c [count]]
```

#### Description

Displays body of the [count](http://msmqmngr.codeplex.com/wikipage?title=count&referringTitle=Documentation) messages referenced by [path](http://msmqmngr.codeplex.com/wikipage?title=path&referringTitle=Documentation), does not remove messages from the queue. Operation stops when either end of queue or
[count](http://msmqmngr.codeplex.com/wikipage?title=count&referringTitle=Documentation) were reached. If count was not specified displays ALL messages in the queue.<br>
<i>Be careful with this one, it will take a while to display the messages if there are tens of thousands of them in the queue.</i>

#### Examples

```
peek /p .\private$\MSMQStudioQueue /c 5
peek /p FormatName:Direct=TCP:127.0.0.1\private$\MSMQStudioQueue
```

<br>

### Copy command

#### Format

```
copy /s [source path] /d [destination path]
```

#### Description

Copies all messages from source queue to destination queue.

#### Example

```
copy /s .\private$\SourceQueue /d .\private$\DestinationQueue
```

<br>

### Export command

#### Format

```
export /p [path] [optional:/f [filename]]
```

#### Description

Exports all messages from source queue to destination file. If name of the file was not provided msmqmng will create new file with the name equal to the queue name adding '.xml' extension. Export command does NOT remove messages from the queue.

#### Examples

```
export /p .\private$\MSMQStudioQueue
 export /p .\private$\MSMQStudioQueue /f C:\QueueData\msmqexport.xml
```

<br>

### Import command

#### Format

```
import /p [path] [optional:/f [filename]]
```

#### Description

Imports all messages from source file to destination queue. If name of the file was not provided msmqmng will search current folder for the file named equally to the queue name with '.xml' extension.

#### Examples

```
import /p .\private$\MSMQStudioQueue
import /p .\private$\MSMQStudioQueue /f C:\QueueData\msmqexport.xml
```

<br>

### Load command

#### Format

```
load /f [filename]
```

#### Description

Loads script file and executes all of the commands in it sequentially, if any of the commands fails execution stops.

#### Example

```
load /f cmd.txt
```

<br>
Sample content of cmd.txt file<br>

```
delete /p tempQueue
create /p tempQueue
copy /s prodQueue /d tempQueue
```

<br>

### Queue name examples

| Example | Description |
| .\MSMQStudioQueue | References a public queue MSMQStudioQueue on the local machine. |
| serverXYZ\MSMQStudioQueue | References a public queue on a machine named serverXYZ. |
| .\private$\MSMQStudioQueue | References a private queue named MSMQStudioQueue on the local machine. |
| serverXYZ\private$\MSMQStudioQueue | References a private queue named MSMQStudioQueue on a machine named serverXYZ. |
| Formatname:DIRECT=OS:.\MSMQStudioQueue | References a public queue named MSMQStudioQueue on the local machine. |
| Formatname:DIRECT=OS:server01\MSMQStudioQueue | References a public queue named MSMQStudioQueue on a machine server01. |
| Formatname:DIRECT=TCP:127.0.0.1\private$\MSMQStudioQueue | References a private queue named MSMQStudioQueue on the local machine. |
