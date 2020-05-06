//Anum Bhamani

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plants : MonoBehaviour {

	public GameObject flower;

	public int seed = 0;

    int treeLength1;

    int treeLength2;
    int treeLength3;

    //float die_prob = 0.1f;

    float pause_prob = 0.4f;
    float[] pause_prob_table;  

    
    List<Branch> branchList = new List<Branch>();
    List<Branch> newBranchList = new List<Branch>();

    int n = 8; 

    float k ;  //length of each branch
    

    // Start is called before the first frame update
    void Start() {    
        Random.InitState(seed);

        k = 10.0f;  //length of each branch

        pause_prob_table = new float[7];
        pause_prob_table[0] = Random.value;
        pause_prob_table[1] = Random.value;
        pause_prob_table[2] = Random.value;
        pause_prob_table[3] = Random.value;
        pause_prob_table[4] = Random.value;
        pause_prob_table[5] = Random.value;
        pause_prob_table[6] = Random.value;

        
		Vector3 position1 = new Vector3(0,0,0); 
		treeLength1 = 4;
		createPlant(position1, treeLength1);

		Random.InitState(seed);
		// pause_prob_table = new float[6];
  //       pause_prob_table[0] = Random.value;
  //       pause_prob_table[1] = Random.value;
  //       pause_prob_table[2] = Random.value;
  //       pause_prob_table[3] = Random.value;
  //       pause_prob_table[4] = Random.value;
  //       pause_prob_table[5] = Random.value;
		Vector3 position2 = new Vector3(-150,0,0); 
		treeLength2 = 3;
		createPlant(position2, treeLength2);

		Random.InitState(seed);
		// pause_prob_table = new float[6];
  //       pause_prob_table[0] = Random.value;
  //       pause_prob_table[1] = Random.value;
  //       pause_prob_table[2] = Random.value;
  //       pause_prob_table[3] = Random.value;
  //       pause_prob_table[4] = Random.value;
  //       pause_prob_table[5] = Random.value;
		Vector3 position3 = new Vector3(150,0,0); 
		treeLength3 = 5;
		createPlant(position3, treeLength3);
        
    }

    // Update is called once per frame
    void Update() {}

    void createPlant(Vector3 p, int TL) {		
    	bool die = false;
    	bool pause = false;
    	int  order = 0;
    	int treeLength = TL;
    	Vector3 position = p;   
        Vector3 T = new Vector3(0,1,0).normalized;
  	    Vector3 B = new Vector3();
        Vector3 N = new Vector3();

		Vector3 R = new Vector3(1, 0, 0); // right vector

        N = Vector3.Cross(T, R).normalized;  // BxT
		B = Vector3.Cross(T, (N)).normalized;

    	Bud bud0 = new Bud(position, T, N, B);     	
	    	
    	Branch trunk = new Branch(bud0, order, pause, die); 
    	branchList.Add(trunk);    	

    	for(int i = 0; i < treeLength; i++) {    		
    		foreach (Branch branch in branchList) {    			
    			List<Branch> sideBranches = grow(branch);    
    			foreach(Branch sb in sideBranches) {    				
    				newBranchList.Add(sb);
    			}			
    		}
    		foreach(Branch nb in newBranchList) {
    			branchList.Add(nb);
    		}
    		newBranchList = new List<Branch>();
    	}
    	foreach(Branch b in branchList) {	
    			Mesh cylinder_mesh = new Mesh();    		
	        	GameObject c = new GameObject("Branch");
				c.AddComponent<MeshFilter>();
				c.AddComponent<MeshRenderer>();	
				c.GetComponent<MeshFilter>().mesh = cylinder_mesh; 

				// change the color of the object
				Renderer rend = c.GetComponent<Renderer>();
				rend.material.color = new Color ((59f/256f), (39f/256f), (19f/256f), 1.0f);	
				
				c.GetComponent<MeshFilter>().mesh.vertices = b.vertexList;
				c.GetComponent<MeshFilter>().mesh.triangles =b.triangleList;
				c.GetComponent<MeshFilter>().mesh.RecalculateNormals();

				if(b.order == 4) {
					int length = b.budList.Count;
			    	Vector3 zeroVector = new Vector3(0,0,0);
			    	Bud tipBud = new Bud(zeroVector, zeroVector, zeroVector, zeroVector);
			    	for (int i = 0; i < length; i++) {
			    		tipBud = b.budList[i];
			    	}	
					//GameObject f = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					GameObject f = (GameObject)Instantiate(flower);
       				f.transform.position = new Vector3((tipBud.position.x), (tipBud.position.y), (tipBud.position.z));
       				f.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
       				
				}
    		}
    }

    //this method will grow buds.
    List<Branch> grow(Branch branch) { 
    	List<Branch> newSideBranches = new List<Branch>();     	
    	//if(!branch.die) {
    		//if(!branch.pause) {
    			int length = branch.budList.Count;
				Vector3 zeroVector = new Vector3(0,0,0);
				Bud tipBud = new Bud(zeroVector, zeroVector, zeroVector, zeroVector);
				for (int i = 0; i < length; i++) {
					tipBud = branch.budList[i];
				}		

				Vector3 U = new Vector3(0,1,0);  //up vector    
				Vector3 D = new Vector3(0,-1,0);  //down vector    Tcos + Nsin
				Vector3 R = new Vector3(1, 0, 0); // right vector
				// float k = 10.0f;  //length of each branch
				
				Vector3 newposition = new Vector3();
				newposition = (tipBud.position + (k * tipBud.T));   

				Vector3 newT = new Vector3();
				Vector3 newN = new Vector3();
				Vector3 newB = new Vector3();
				newT = (newposition - tipBud.position).normalized;
				

				//ortho
				float o = 0.5f;
				newT = (newT + o * new Vector3(0,1,0)).normalized;

				////Adding wiggle
				float randN = Random.Range(-1, 1);
				float randB = Random.Range(-1, 1);
			    newT = (newT + (newN * randN) + (newB * randB)).normalized;

				if ((newT == new Vector3(0,1,0)) || (newT == new Vector3(0,-1,0))) {
					Vector3 tempT = new Vector3(1,0,0);    			
					newN = Vector3.Cross(newT, R).normalized;  // BxT
					newB = Vector3.Cross(newT, (newN)).normalized;  // (TxN) / |TxN|
				} else {
					newN = Vector3.Cross(newT, D).normalized;  // BxT
					newB = Vector3.Cross(newT, (newN)).normalized;  // (TxN) / |TxN|
				}			     
				     	
				Bud newBud = new Bud(newposition, newT, newN, newB);
				branch.budList.Add(newBud);   	    	   
				
				Vector3[] newVertexList = new Vector3[branch.vertexList.Length + 9];

				int index = branch.vertexList.Length - 1;

				for (int i = 0; i < branch.vertexList.Length; i++) {
					newVertexList[i] = branch.vertexList[i];
				}
				branch.vertexList = newVertexList; 
				
				index  = branch.vertexList.Length - 1;

				// branch.radius = branch.radius - 0.1f;

				branch.vertexList[index - 8] = new Vector3(newBud.position.x, newBud.position.y, newBud.position.z);

				
			    float baseAngle = 45f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 7] = new Vector3(x,y,z);


			    baseAngle = 90f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x1 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y1 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z1 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;    	
			   	branch.vertexList[index - 6] = new Vector3(x1,y1,z1);


			    baseAngle = 135f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x2 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y2 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z2 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 5] = new Vector3(x2,y2,z2);	    	

			    baseAngle = 180f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x3 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y3 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z3 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 4] = new Vector3(x3,y3,z3);	 

			    baseAngle = 225f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x4 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y4 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z4 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 3] = new Vector3(x4,y4,z4);

			    baseAngle = 270f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x5 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y5 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z5 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
			   	branch.vertexList[index- 2] = new Vector3(x5,y5,z5);

			    baseAngle = 315f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			  	float x6 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y6 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z6 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 1] = new Vector3(x6,y6,z6);
			    	

			    baseAngle = 360f;
			   	baseAngle = baseAngle * Mathf.Deg2Rad;
			   	float x7 = ((((newBud.N.x) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.x) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.x;
			   	float y7 = ((((newBud.N.y) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.y) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.y;
			   	float z7 = ((((newBud.N.z) * Mathf.Cos(baseAngle)) * branch.radius) + (((newBud.B.z) * Mathf.Sin(baseAngle)) * branch.radius)) + newBud.position.z;
				branch.vertexList[index - 0] = new Vector3(x7,y7,z7);


				int[] newTriangleList = new int[(branch.triangleList.Length) + (24 * 3)];
				
				for (int i = 0; i < branch.triangleList.Length; i++) {
					newTriangleList[i] = branch.triangleList[i];
				}
				branch.triangleList = newTriangleList;

			    //octagon
				
				//1
				branch.triangleList[branch.triangleList.Length - 1 - 71] = index - 8; //11
				branch.triangleList[branch.triangleList.Length - 1 - 70] = index - 7; //10
				branch.triangleList[branch.triangleList.Length - 1 - 69] = index - 6; //9

				//2
				branch.triangleList[branch.triangleList.Length - 1 - 68] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 67] = index - 6;
				branch.triangleList[branch.triangleList.Length - 1 - 66] = index - 5;

				//3
				branch.triangleList[branch.triangleList.Length - 1 - 65] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 64] = index - 5;
				branch.triangleList[branch.triangleList.Length - 1 - 63] = index - 4;

				//4
				branch.triangleList[branch.triangleList.Length - 1 - 62] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 61] = index - 4;
				branch.triangleList[branch.triangleList.Length - 1 - 60] = index - 3;

				//5
				branch.triangleList[branch.triangleList.Length - 1 - 59] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 58] = index - 3;
				branch.triangleList[branch.triangleList.Length - 1 - 57] = index - 2;

				//6
				branch.triangleList[branch.triangleList.Length - 1 - 56] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 55] = index - 2;
				branch.triangleList[branch.triangleList.Length - 1 - 54] = index - 1;

				//7
				branch.triangleList[branch.triangleList.Length - 1 - 53] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 52] = index - 1;
				branch.triangleList[branch.triangleList.Length - 1 - 51] = index - 0;

				//8
				branch.triangleList[branch.triangleList.Length - 1 - 50] = index - 8;
				branch.triangleList[branch.triangleList.Length - 1 - 49] = index - 0;
				branch.triangleList[branch.triangleList.Length - 1 - 48] = index - 7;


				// RECT
				
				branch.triangleList[branch.triangleList.Length - 1 - 47] = index - 7; //10 
				branch.triangleList[branch.triangleList.Length - 1 - 46] = index - 16;  //1
				branch.triangleList[branch.triangleList.Length - 1 - 45] = index - 15; //2

				branch.triangleList[branch.triangleList.Length - 1 - 44] = index - 15;  //2    
				branch.triangleList[branch.triangleList.Length - 1 - 43] = index - 6;  //11
				branch.triangleList[branch.triangleList.Length - 1 - 42] = index - 7;  //10


				 //2
				branch.triangleList[branch.triangleList.Length - 1 - 41] = index - 6; //11
				branch.triangleList[branch.triangleList.Length - 1 - 40] = index - 15; //2
				branch.triangleList[branch.triangleList.Length - 1 - 39] = index - 14; //3

				branch.triangleList[branch.triangleList.Length - 1 - 38] = index - 14; //3
				branch.triangleList[branch.triangleList.Length - 1 - 37] = index - 5; //12
				branch.triangleList[branch.triangleList.Length - 1 - 36] = index - 6; //11
				

				//3
				branch.triangleList[branch.triangleList.Length - 1 - 35] = index - 5; //12
				branch.triangleList[branch.triangleList.Length - 1 - 34] = index - 14; //3
				branch.triangleList[branch.triangleList.Length - 1 - 33] = index - 13; //4

				branch.triangleList[branch.triangleList.Length - 1 - 32] = index - 13; //4
				branch.triangleList[branch.triangleList.Length - 1 - 31] = index - 4; //13
				branch.triangleList[branch.triangleList.Length - 1 - 30] = index - 5; //12


				// 4
				branch.triangleList[branch.triangleList.Length - 1 - 29] = index - 4; //13 
				branch.triangleList[branch.triangleList.Length - 1 - 28] = index - 13; //4
				branch.triangleList[branch.triangleList.Length - 1 - 27] = index - 12;  //5

				branch.triangleList[branch.triangleList.Length - 1 - 26] = index - 12; //5
				branch.triangleList[branch.triangleList.Length - 1 - 25] = index - 3;  //14
				branch.triangleList[branch.triangleList.Length - 1 - 24] = index - 4;  //13


				//5
				branch.triangleList[branch.triangleList.Length - 1 - 23] = index - 3; //14 
				branch.triangleList[branch.triangleList.Length - 1 - 22] = index - 12; //5
				branch.triangleList[branch.triangleList.Length - 1 - 21] = index - 11; //6

				branch.triangleList[branch.triangleList.Length - 1 - 20] = index - 11; //6
				branch.triangleList[branch.triangleList.Length - 1 - 19] = index - 2; //15
				branch.triangleList[branch.triangleList.Length - 1 - 18] = index - 3; //14

				//6
				branch.triangleList[branch.triangleList.Length - 1 - 17] = index - 2; //15
				branch.triangleList[branch.triangleList.Length - 1 - 16] = index - 11; //6
				branch.triangleList[branch.triangleList.Length - 1 - 15] = index - 10; //7

				branch.triangleList[branch.triangleList.Length - 1 - 14] = index - 10; //7
				branch.triangleList[branch.triangleList.Length - 1 - 13] = index - 1; //16
				branch.triangleList[branch.triangleList.Length - 1 - 12] = index - 2; //15


				//7
				branch.triangleList[branch.triangleList.Length - 1 - 11] = index - 1; //16
				branch.triangleList[branch.triangleList.Length - 1 - 10] = index - 10; //7
				branch.triangleList[branch.triangleList.Length - 1 - 9] = index - 9;  //8

				branch.triangleList[branch.triangleList.Length - 1 - 8] = index - 9; //8
				branch.triangleList[branch.triangleList.Length - 1 - 7] = index - 0;  //17
				branch.triangleList[branch.triangleList.Length - 1 - 6] = index - 1;  //16

				//8
				branch.triangleList[branch.triangleList.Length - 1 - 5] = index - 0; //17
				branch.triangleList[branch.triangleList.Length - 1 - 4] = index - 9;  //8
				branch.triangleList[branch.triangleList.Length - 1 - 3] = index - 16;  //1

				branch.triangleList[branch.triangleList.Length - 1 - 2] = index - 16; //1
				branch.triangleList[branch.triangleList.Length - 1 - 1] = index - 7; //10
				branch.triangleList[branch.triangleList.Length - 1 - 0] = index - 0;  //17


				//List<Branch> newSideBranches = new List<Branch>();

				float randSideBuds = Random.Range(0.0f, 3.0f);
				//int num_sideBuds = 1;
				int num_sideBuds = (int) randSideBuds;
				

				for (int i = 0; i < num_sideBuds; i++) {    		   		   
					float newStartAngle = branch.startAngle + ((360.0f / num_sideBuds) * i);
					newStartAngle = newStartAngle * Mathf.Deg2Rad;
					Vector3 sideNewT = ((newBud.N * Mathf.Cos(newStartAngle)) + (newBud.B * Mathf.Sin(newStartAngle))).normalized;
					sideNewT = Vector3.RotateTowards(sideNewT, newT, 30f * Mathf.Deg2Rad, 0.0f);

					//changed
					if ((sideNewT == new Vector3(0,1,0)) || (sideNewT == new Vector3(0,-1,0))) {
			    		Vector3 tempT = new Vector3(1,0,0);    			
			    		newN = Vector3.Cross(sideNewT, R).normalized;  // BxT
			    		newB = Vector3.Cross(sideNewT, (newN)).normalized;  // (TxN) / |TxN|
			    	} else {
			    		newN = Vector3.Cross(sideNewT, D).normalized;  // BxT
			    		newB = Vector3.Cross(sideNewT, (newN)).normalized;  // (TxN) / |TxN|
			    	}
			    	// Vector3 newT = new Vector3(0,1,0).normalized;
					// newN = Vector3.Cross(newT, D).normalized;  // BxT
						// newB = Vector3.Cross(newT, newN).normalized;

					Bud newSideBud = new Bud(newposition, sideNewT, newN, newB); 

					int newOrder = branch.order;    		 		    		  

					if ((newOrder + 1) <= 6) { 				
						newOrder = newOrder + 1; 
						if(newOrder <= 6) {
							if(pause_prob_table[newOrder] > pause_prob) {
	    						branch.pause = true;
	    					}
						}

						Branch newSideBranch = new Branch(newSideBud, newOrder, branch.pause, branch.die);
						newSideBranches.Add(newSideBranch);
					} else {
						branch.die = true;
					}
					
					    		    		   		
				}    	      
				// add to start angle
				branch.startAngle += 0.45f;  //change this
				//k--;
				// branch.radius = branch.radius - 0.1f;
				//return newSideBranches;  
    		//}
    		
    	//}

    	return newSideBranches;
    }

    void drawSpheres(){
    	foreach(Branch b in branchList) {
    		foreach(Bud bu in b.budList) {
    			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        		sphere.transform.position = new Vector3(bu.position.x, bu.position.y, bu.position.z);
    		}
    	}    	 
    }

    public class Bud {
    	public Vector3 position;
	    public Vector3 T;
	    public Vector3 B;
	    public Vector3 N;

		public Bud(Vector3 position, Vector3 T, Vector3 N, Vector3 B) {
			this.T = T;
			this.B = B;
			this.N = N;
			this.position = position;
		}
    }

    public class Branch {
    	public List<Bud> budList;
	    public bool pause;
	    public bool die; 
	    public int order;
	    public float startAngle; 

	    public Vector3[] vertexList;
		public int[] triangleList;
		public float radius = 1.5f;  //k for creating cylinders

		public Branch(Bud bud0, int order, bool pause, bool die) {
			this.order = order;
			this.pause = pause;
			this.budList = new List<Bud>();
			budList.Add(bud0);
			this.die = die;
			startAngle = 0.0f;
			
			this.vertexList = new Vector3[8+1];  //n
    		this.triangleList = new int[8*3];

    	vertexList[0] = new Vector3(bud0.position.x, bud0.position.y, bud0.position.z);

	    float baseAngle = 45f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
    	vertexList[1] = new Vector3(x,y,z);
    	//instantiate sphere tat xyz, make it white
    	

	    baseAngle = 90f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x1 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y1 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z1 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;    	
	   	vertexList[2] = new Vector3(x1,y1,z1);


	    baseAngle = 135f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x2 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y2 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z2 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
    	vertexList[3] = new Vector3(x2,y2,z2);	    	

	    baseAngle = 180f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x3 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	  	float y3 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
    	float z3 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;	    	vertexList[4] = new Vector3(x3,y3,z3);
    	vertexList[4] = new Vector3(x3,y3,z3);

	    baseAngle = 225f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x4 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y4 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z4 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
    	vertexList[5] = new Vector3(x4,y4,z4);

	    baseAngle = 270f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x5 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y5 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z5 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
	   	vertexList[6] = new Vector3(x5,y5,z5);

	    baseAngle = 315f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	  	float x6 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y6 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z6 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
    	vertexList[7] = new Vector3(x6,y6,z6);
	    	

	    baseAngle = 360f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	float x7 = ((((bud0.N.x) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.x) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.x;
	   	float y7 = ((((bud0.N.y) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.y) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.y;
	   	float z7 = ((((bud0.N.z) * Mathf.Cos(baseAngle)) * radius) + (((bud0.B.z) * Mathf.Sin(baseAngle)) * radius)) + bud0.position.z;
    	vertexList[8] = new Vector3(x7,y7,z7);

    	this.triangleList = new int[24];
    	triangleList[0] = 0;
    	triangleList[1] = 1;
    	triangleList[2] = 2;

    	triangleList[3] = 0;
    	triangleList[4] = 2;
    	triangleList[5] = 3;

    	triangleList[6] = 0;
    	triangleList[7] = 3;
    	triangleList[8] = 4;

    	triangleList[9] = 0;
    	triangleList[10] = 4;
    	triangleList[11] = 5;

    	triangleList[12] = 0;
    	triangleList[13] = 5;
    	triangleList[14] = 6;

    	triangleList[15] = 0;
    	triangleList[16] = 6;
    	triangleList[17] = 7;

    	triangleList[18] = 0;
    	triangleList[19] = 7;
    	triangleList[20] = 8;

    	triangleList[21] = 0;
    	triangleList[22] = 8;
    	triangleList[23] = 1;

		}
    }
}
