User stories

1. create first the library layer (will contain gzip code and will allow to also use another one as source: zip, tar, etc)
2. download file by name (date) async
3. do we use redis to process the data?
4. add to a memory the data to process sing linq?
3. process the first report (use multiple thread if necesary)
4. 



High level Process

-- Getting data
1. Create a temporary folder with the data
2. Download the files in a folder
3. Decompressing the files from the folder

-- Analyze the data
1. Create a database using entity framework
2. Search if we can handle each file in memory to process the data (disposable) 
3. Process each file by day (in one instance)
4. 

-- Reporting the results