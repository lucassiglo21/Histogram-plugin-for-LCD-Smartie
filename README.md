# Histogram-plugin-for-LCD-Smartie
This plugin allows the user to show histograms on your display

![pic](Demo.png)

Supports 1,2,3 and 4 row histograms and an arbitrary amount of columns

Supports multiple histograms of arbitrary size on a single screen

Compatible with proc plugin on the same screen as it uses the same custom caracters

The syntax is very similar to the one used by the proc plugin, but you can use an arbitrary value as an input. 
This is particularly useful for showing histograms of system information that's not available as a performance counter but through the openhardwaremonitor library via the Sensor Bridge plugin https://lcdsmartie.org/forums/viewtopic.php?t=3377 or nvapi. For example, global GPU usage and VRAM.

### Syntax:

Top row:
```
$dll(histogram,1,HxW#time#min#max#value,name)
```
Following rows:
```
$dll(histogram,2,name,row)
```
Where:
```
H=histogram height
W=histogram width
time=refresh interval in 0.1 second units
min=minimum value of the histogram
max=maximum value of the histogram
value= input value for the plugin, typically another plugin like Sensor Bridge (for example value=$dll(SB,5,4,0))
name=histogram name so you can use multiple histograms on a single screen
row= row number from the bottom
```

### 4 row usage example:
```
$dll(histogram,1,4x14#8#0#100#value,name)
$dll(histogram,2,name,3)
$dll(histogram,2,name,2)
$dll(histogram,2,name,1)
```

### 3 row usage example:
```
$dll(histogram,1,3x14#8#0#100#value,name)
$dll(histogram,2,name,2)
$dll(histogram,2,name,1)
```

### 2 row usage example:
```
$dll(histogram,1,2x14#8#0#100#value,name)
$dll(histogram,2,name,1)
```

### 1 row usage example:
```
$dll(histogram,1,1x14#8#0#100#value,name)
```
