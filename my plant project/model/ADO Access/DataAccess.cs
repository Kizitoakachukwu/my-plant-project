using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace my_plant_project
{
    internal class DataAccess
    {
        static  string connctionString = ConfigurationManager.ConnectionStrings["my_plant_project.Properties.Settings.PlantsConnectionString"].ToString();
        SqlConnection connection=new SqlConnection(connctionString);


        public List<plants> GetPlants()
        {
            List<plants> plantsList = new List<plants>();
            connection.Open();
            string Request = "select id, name,name_plan from dbo.Plants";
            SqlCommand cmd = new SqlCommand(Request, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    plants plants = new plants();
                    plants.Id = reader.GetInt32(0);
                    plants.name = reader["Name"].ToString();
                    plants.name_plan = reader["name_plan"].ToString();
                    plantsList.Add(plants);

                }
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            connection.Close();
            return plantsList;
        }
        public List<Operation> GetOperations()
        {
           List<Operation> Operationlist = new List<Operation>();
            connection.Open();
            string request = "Select id, name from dbo.Operetion";
            SqlCommand cmd = new SqlCommand(request, connection);
            SqlDataReader reader =  cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Operation operation = new Operation();
                    operation.name = reader.GetString(1);
                    operation.Id = reader.GetInt32(0);
                    Operationlist.Add(operation);
                }
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            connection.Close ();
            return Operationlist;
        }
        public List<Operationlist> GetOperationlists()
        {
            List<Operationlist> Operationlists = new List<Operationlist>();
            connection. Open();
            string request = "SELECT ol.date,ol.id,h.id,h.name,sp.id,sp.name,o.id,o.name,p.id,p.name,p.name_plan  from Operation_list ol\r\ninner join dbo.Operetion o \r\ninner join dbo.Plants p\r\ninner join dbo.harmful_objz h\r\ninner join dbo.special_treatment sp";
            SqlCommand command = new SqlCommand(request, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Operationlist operationlist = new Operationlist
                    {

                        date=reader.GetDateTime(1),
                        Id=reader.GetInt32(0),
                        harmful_Obj=new Harmful_obj
                        {
                            Id=reader.GetInt32(0),
                            name=reader.GetString(1),
                            specialTreatment = new special_treatment
                            {
                                Id=reader.GetInt32(0),
                                Name=reader.GetString(1)
                            }

                        },
                        Operation=new Operation
                        {
                            Id = reader.GetInt32(0),
                            name=reader.GetString(0),

                        },
                        plants=new plants
                        {
                            Id=reader.GetInt32(0),
                            name=reader.GetString(0),
                            name_plan=reader.GetString(0),
                        }

                    };
                    Operationlists.Add(operationlist);
                }
            }
            return Operationlists;
        }
        public List<Details> GetDetails()
        {
            List<Details> details = new List<Details>();
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) 
            {
                while (reader.Read())
                { 
                 
                     Details details1 = new Details();
                    details1.Id = reader.GetInt32(0);
                    Operation operation = new Operation();
                    operation.Id =reader.GetInt32(0);
                    operation.name=reader.GetString(1);
                    details1.Disease = reader["Disease"].ToString();
                    details1.Period = reader.GetDateTime(1);

                    details.Add(details1);
                }
            }
            return details;
        }
        public List<Harmful_obj> GetHarmful_Objs()
        {
            List<Harmful_obj> list = new List<Harmful_obj>();
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Harmful_obj obj = new Harmful_obj();
                    obj.Id = reader.GetInt32(0);
                    obj.name= reader.GetString(1);
                    special_treatment special_Treatment = new special_treatment();
                    {
                        special_Treatment.Id = reader.GetInt32(0);
                        special_Treatment.Name = reader.GetString(1);
                    }
                }
                           
            }
        
            return list;
        }
        public List<MethodTreatment> GetMethodTreatment()
        {
            List<MethodTreatment> list = new List<MethodTreatment>();
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MethodTreatment obj = new MethodTreatment();
                    obj.Id= reader.GetInt32(0);
                obj.Name = reader.GetString(1);
                   
                }
            }
            return list;
        }
        public List<special_treatment> Getspecial_treatment()
        {
            List<special_treatment>list = new List<special_treatment>();
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    special_treatment obj = new special_treatment();
                    obj.Id=reader . GetInt32(0);
                    obj.Name = reader.GetString(1);
                }
            
                        }

             return list;
        }
       




        public void Insert(plants plants)
        {
            connection.Open();
            string Request = "insert into  Plants.dbo.Plants  values (@Name,@Nameplan)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("Name", plants.name);
            cmd.Parameters.AddWithValue("Nameplan", plants.name_plan);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(Operation operation)
        {
            connection.Open();
            string Request = "insert into dbo.Operation values(@name)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", operation.name);
            cmd.Parameters.AddWithValue("Id", operation.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(Details details)
        {
            connection.Open();
            string Request = "insert into dbo.Details values(@operationID,@Disease,@Period)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("operationID", details.operation.Id);
            cmd.Parameters.AddWithValue("Disease", details.Disease);
            cmd.Parameters.AddWithValue("Period", details.Period);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(Harmful_obj harmful_Obj)
        {
            connection.Open();
            string Request = "insert into dbo.harmful_Obj values(@name,@spId)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", harmful_Obj.name);
            cmd.Parameters.AddWithValue("spId", harmful_Obj.specialTreatment.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(MethodTreatment methodTreatment)
        {
            connection.Open();
            string Request = "insert into dbo.method_treatment values(@name,@name_plan)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", methodTreatment.Name);
            cmd.Parameters.AddWithValue("name_plan", methodTreatment.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(Operationlist operationlist)
        {
            connection.Open();
            string Request = "insert into dbo.Operation_list values (@name,@opId,@hId)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", operationlist.date);
            cmd.Parameters.AddWithValue("OpId", operationlist.Operation.Id);
            cmd.Parameters.AddWithValue("hId", operationlist.harmful_Obj.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }





        public void Update(plants plants)
        {
            connection.Open();
            string Request = "insert into  Plants.dbo.Plants  values (@Name,@Nameplan)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("Name", plants.name);
            cmd.Parameters.AddWithValue("Nameplan", plants.name_plan);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Operation operation)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", operation.name);
            cmd.Parameters.AddWithValue("Id", operation.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Details details)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("operationID", details.operation.Id);
            cmd.Parameters.AddWithValue("Disease", details.Disease);
            cmd.Parameters.AddWithValue("Period", details.Period);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Harmful_obj harmful_Obj)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", harmful_Obj.name);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(MethodTreatment methodTreatment)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", methodTreatment.Name);
            cmd.Parameters.AddWithValue("name_plan", methodTreatment.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Operationlist operationlist)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", operationlist.date);
            cmd.Parameters.AddWithValue("name", operationlist.Id);
            cmd.Parameters.AddWithValue("name_plan", operationlist.Operation.Id);
            cmd.Parameters.AddWithValue("name_plan", operationlist.harmful_Obj.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }



        public void Delete(plants plants)
        {
            connection.Open();
            string Request = "delete from  Plants.dbo.Plants  where @Id";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("id", plants.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Operation operation)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("Id", operation.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Details details)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("ID", details.Id);
           
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Harmful_obj harmful_Obj)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("id", harmful_Obj.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(MethodTreatment methodTreatment)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("id", methodTreatment.Id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Operationlist operationlist)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("id", operationlist.Id);
         
            connection.Close();
        }

        internal void Insert(special_treatment special_treatment)
        {
            connection.Open();
            string Request = "insert into dbo.special_treatment values(@name)";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", special_treatment.Name);

            connection.Close();
        }

        internal void Delete(special_treatment special_treatment)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", special_treatment.Name);

            connection.Close();
        }

        internal void Update(special_treatment special_treatment)
        {
            connection.Open();
            string Request = "";
            SqlCommand cmd = new SqlCommand(Request, connection);
            cmd.Parameters.AddWithValue("name", special_treatment.Name);

            connection.Close();
        }
    }
}
