#!/bin/bash
#
# Script Name: zipfiles.sh
#
# Author: Anders V. Riis 
# Date : December, 2017 
#
# Description: Formålet med dette program er at lave en samlet afleveringsmappe til faget PoP
#
# Kan bl.a. køres med bash zipfiles.sh

opg="10g"
basefilenam="files"
filename="$opg$basefilenam"
name="AndersRiis.zip"
zipfilename="$opg$name"

while read p; do
  zip $zipfilename $p
done < $filename

