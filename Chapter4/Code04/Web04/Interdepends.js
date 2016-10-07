
        
function populateListB()
{

itemarray = 
    listsB[document.all.ddlListA.selectedIndex];
valuearray = 
    valuesB[document.all.ddlListA.selectedIndex];	
ctlListB = 
    document.all.ddlListB;
for (i=ctlListB.options.length; i>0; i--)
{ctlListB.options[i] = null;}

for (i=0; i<itemarray.length; i++)
{ctlListB.options[i] = new Option(itemarray[i],valuearray[i]);}
    
} 

