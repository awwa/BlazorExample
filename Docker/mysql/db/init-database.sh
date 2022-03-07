mysql -u root -ppassword -e "CREATE DATABASE hoge_blazor;"
mysql -u root -ppassword -e "ALTER USER 'root' IDENTIFIED WITH mysql_native_password BY 'password';"
mysql -u root -ppassword -e "flush privileges;"
