i=0
echo "Starting dotnet server. Please wait....";
cd /usercode/Educative.API && dotnet run --urls=http://localhost:5000 > /dev/null 2>&1 & 
while :
do
   curl http://localhost:5000/educative/Addresses >& log.txt;
   if grep "curl: (7) Failed to connect to localhost port 5000: Connection refused" < log.txt > waste.txt; then
   i=0
   else
      echo "Server started :D";
      break;
   fi
done
