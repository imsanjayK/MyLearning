## Execution permissions
```sh
Get-ExecutionPolicy
```

The execution policies you can use are:
- Restricted - Scripts won't run.
- RemoteSigned - Scripts created locally will run, but those downloaded from the Internet will not (unless they are digitally signed by a trusted publisher).
- AllSigned - Scripts will run only if they have been signed by a trusted publisher.
- Unrestricted - Scripts will run regardless of where they have come from and whether they are signed.

You can set PowerShell's execution policy by using the following cmdlet:
```sh
Set-ExecutionPolicy <policy name>
```

## Running a script
Instead of typing the script's full path in such a situation, you can enter .\ and the script's name. For example, you might type:
```sh
.\Script.ps1
```

## Pipelining
Pipelining is the term for feeding one command's output into another command. This allows the second command to act on the input it has received. To pipeline two commands (or cmdlets), simply separate them with the pipe symbol (|).
To help you understand how pipelining works, imagine that you want to create a list of processes that are running on a server and sort that list by process ID number. You can get a list of processes by using the Get-Process cmdlet, but the list will not be sorted. However, if you pipeline the cmdlet's output into the Sort-Object ID command, the list will be sorted. The string of commands used looks like this:

```sh
Get-Process | Sort-Object ID
```

## Variables
Although you can use pipelining to feed one command's output into another command, sometimes pipelining alone won't get the job done. When you pip
eline a command's output into another command, that output is used immediately. Occasionally, you may need to store the output for a while so that you can use (or reuse) it later. This is where variables come into play.

It's easy to think of a variable as a repository for storing a value, but in PowerShell, a variable can store a command's full output. For example, suppose you want to store the list of processes running on a server as a variable. To do so, you could use this line of code:
```sh
$a = Get-Process
```
Here, the variable is named $a. If you want to use the variable, simply call it by name. For example, typing $a prints the variable's contents on the screen.

You can assign a variable to the final output of multiple commands that have been pipelined together. Just surround the commands with parentheses. For example, to sort the running processes by process ID and then assign the output to a variable, you could use this command:
```sh
$a = (Get-Process | Sort-Object ID)
```

## The @ symbol
By using the @ symbol, you can turn the contents of a list into an array. For example, take the following line of code, which creates a variable named $Procs that contains multiple lines of text (an array):
```sh
$procs = @{name="explorer","svchost"}
```
You can also use the @ symbol when the variable is used, to ensure that it is treated as an array rather than a single value. For instance, the line of code below will run the Get-Process cmdlet against the variable.the @ symbol is being used in front of the variable name rather than the dollar sign that we usually see used:
```sh
Get-Process @procs
```

## Split
The split operator splits a text string based on a character you designate. For example, suppose that you want to break a sentence into an array consisting of each individual word in the sentence. You could do so by using a command like this one:
```sh
"This is a test" -split " "
```
>The result would look like this:
This
is
a
test

## Join
Just as split can split a text string into multiple pieces, the join operator can combine multiple blocks of text into one. For example, this line will create a text string consisting of my first name and last name:
```sh
"Brien","Posey" -join " "
```
The space between the quotation marks at the end of the command tells Windows to insert a space between the two text strings.

## Breakpoints
Running a newly created PowerShell script can have unintended consequences if the script contains bugs. One way to protect yourself is to insert breakpoints at strategic locations within your script. That way, you can make sure that the script is working as intended before you process the entire thing.
The easiest way to insert a breakpoint is by line number. For instance, to insert a break point on the 10th line of a script, you could use a command like this:
```sh
New-PSBreakpoint -Script C:\Scripts\Script.ps1 -Line 10
```
You can also bind a breakpoint to a variable. So if you wanted your script to break any time the contents of a$ changed, you could use a command like this one:
```sh
New-PSBreakpoint -Script C:\scripts\Script.ps1 -variables a
```
There are a number of verbs you can use with PSBreakpoint including New, Get, Enable, Disable, and Remove.

## Step
When debugging a script, it may sometimes be necessary to run the script line by line. To do so, you can use the '**Step-Into** cmdlet. This will cause the script to pause after each line regardless of whether a breakpoint exists. When you are done, you can use the **Step-Out** cmdlet to stop Windows from stepping through the script. It is worth noting, however, that breakpoints are still processed even after the **Step-Out** cmdlet has been used.

Incidentally, if your script uses functions, you may be interested in the **Step-Over** cmdlet. **Step-Over** works just like **Step-Into**, except that if a function is called, Windows won't step through it. The entire function will run without stopping.