
Create a credhub service through the broker in the CF CLI:

`cf create-service credhub default credhub-test -c '{"MY_DB_CONNECTION_STRING":"http://user1:admin@example.com/super-secret-database"}'`