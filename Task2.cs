NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" +
					     "Password=monomah321;Database=postgres;");

NpgsqlCommand com = new NpgsqlCommand("SELECT \"CustomerId\" from \"Purchases\" p" +
" where (select count(\"ProductName\") from \"Purchases\" where \"ProductName\" = 'cream' and \"CustomerId\" = p.\"CustomerId\") = 0 "+
" and (select count(\"ProductName\") from \"Purchases\" where \"ProductName\" = 'milk' and \"CustomerId\" = p.\"CustomerId\") > 0", conn);

DataSet ds = new DataSet();

NpgsqlDataAdapter da = new NpgsqlDataAdapter(com.CommandText, conn);

da.Fill(ds, "\"Purchases\"");

dataGridView1.DataSource = ds.Tables["\"Purchases\""];
