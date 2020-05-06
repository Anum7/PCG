using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour {
	public int masterSeed = 0;
    int seed1, seed2, seed3, seed4, seed5;

    Vector3[] positions;

    Vector3 T = new Vector3();
    Vector3 N = new Vector3();
    Vector3 B = new Vector3();

    List<Vector3> cylinderList;
    List<Vector3> midPointList;

    List<Vector3> TcylinderList;
    List<Vector3> FcylinderList;

    Vector3[] vertexList;
	int[] triangleList;

	int vertexListLength;
	int triangleListLength;

	public Vector3[] upper;
    public Vector3[] lower;

    string[] bodyArray = new string[3];
    string[] tailArray = new string[3];
    string[] finNumArray = new string[4];
    string[] eyeArray = new string[2];

	private int ntris;
    int index;

    //how many points in a line
    int numPoints = 30;
    int numPointsM = 4;

    float radius;
    int radiusTrack;

    string quad = "";
    string bodyType = "";
    string tailType = "";
    string finType = "";
    string eyeType = "";
    bool tailCheck;

    public Transform point1, point2, point3, point4;
    public Transform point5, point6, point7, point8;
    public Transform Umouthp1, Umouthp2, Umouthc1, Umouthc2;
    public Transform Lmouthp1, Lmouthp2, Lmouthc1, Lmouthc2;
    public Transform tailp1, tailp2, tailc1, tailc2; 
    public Transform Ltailp1, Ltailp2, Ltailc1, Ltailc2; 

    public Transform Ufinp1, Ufinp2, Ufinc1, Ufinc2;
    public Transform Lfinp1, Lfinp2, Lfinc1, Lfinc2;

    
    void Start() {
    	//Initializing arrays
    	for (int i = 0; i < 3; i++) {
    		if (i == 0) {
    			bodyArray[i] = "ONE";
    			tailArray[i] = "ONE";
    			finNumArray[i] = "ONE";
    			eyeArray[i] = "ONE";
    		}
    		if (i == 1) {
    			bodyArray[i] = "TWO";
    			tailArray[i] = "TWO";
    			finNumArray[i] = "TWO";
    			eyeArray[i] = "TWO";
    		}
    		if (i == 2) {
    			bodyArray[i] = "THREE";
    			tailArray[i] = "THREE";
    			finNumArray[i] = "THREE";
    		}
    	}
    	finNumArray[3] = "ZERO";

    	Random.InitState(masterSeed);
    	seed1 = Random.Range(1, 100);
    	seed2 = Random.Range(101, 200);
    	seed3 = Random.Range(201, 300);
    	seed4 = Random.Range(301, 400);
    	seed5 = Random.Range(401, 500);

    	print("Seed 1: " + seed1);
    	print("Seed 2: " + seed2);
    	print("Seed 3: " + seed3);
    	print("Seed 4: " + seed4);
    	print("Seed 5: " + seed5);

    	Random.InitState(seed1);
    	int updatedSeed1T = Random.Range(0, 3);
    	int updatedSeed1B = Random.Range(0, 3);
    	int updatedSeed1F = Random.Range(0, 4);
    	int updatedSeed1E = Random.Range(0,2);
    	print("FISH 1");
    	print("T INDEX1: " + updatedSeed1T);
    	print("B INDEX1: " + updatedSeed1B);
    	print("F INDEX1: " + updatedSeed1F);

    	Random.InitState(seed2);
    	int updatedSeed2T = Random.Range(0, 3);
    	int updatedSeed2B = Random.Range(0, 3);
    	int updatedSeed2F = Random.Range(0, 4);
    	int updatedSeed2E = Random.Range(0,2);
    	print("FISH 2");
    	print("T INDEX2: " + updatedSeed2T);
    	print("B INDEX2: " + updatedSeed2B);
    	print("F INDEX2: " + updatedSeed2F);

    	Random.InitState(seed3);
    	int updatedSeed3T = Random.Range(0, 3);
    	int updatedSeed3B = Random.Range(0, 3);
    	int updatedSeed3F = Random.Range(0, 4);
    	int updatedSeed3E = Random.Range(0,2);
    	print("FISH 3");
    	print("T INDEX3: " + updatedSeed3T);
    	print("B INDEX3: " + updatedSeed3B);
    	print("F INDEX3: " + updatedSeed3F);

    	Random.InitState(seed4);
    	int updatedSeed4T = Random.Range(0, 3);
    	int updatedSeed4B = Random.Range(0, 3);
    	int updatedSeed4F = Random.Range(0, 4);
    	int updatedSeed4E = Random.Range(0,2);
    	print("FISH 4");
    	print("T INDEX4: " + updatedSeed4T);
    	print("B INDEX4: " + updatedSeed4B);
    	print("F INDEX4: " + updatedSeed4B);

    	Random.InitState(seed5);
    	int updatedSeed5T = Random.Range(0, 3);
    	int updatedSeed5B = Random.Range(0, 3);
    	int updatedSeed5F = Random.Range(0, 4);
    	int updatedSeed5E = Random.Range(0,2);
    	print("FISH 5");
    	print("T INDEX5: " + updatedSeed5T);
    	print("B INDEX5: " + updatedSeed5B);
    	print("B INDEX5: " + updatedSeed5F);

    	Vector3[] finalPosition = new Vector3[5];
    	int randNum = Random.Range(0,4);
    	print("randNum " + randNum);
    	if (randNum == 0) {
    		int x = -50;
    		finalPosition[0] = new Vector3(x, 0, 0);
    		x+= 38;
    		finalPosition[1] = new Vector3(x, 0, 0);
    		x+= 38;
    		finalPosition[2] = new Vector3(x, 0, 0);
    		x+= 38;
    		finalPosition[3] = new Vector3(x, 0, 0);
    		x+= 38;
    		finalPosition[4] = new Vector3(x, 0, 0);
		} else if (randNum == 1) {
			finalPosition[0] = new Vector3(0,0,0);
			finalPosition[1] = new Vector3(16.1f, 0f, -14.1f);
			finalPosition[2] = new Vector3(14.1f, 0f, -37.5f);
			finalPosition[3] = new Vector3(-6.6f, 0f, -19.6f);
			finalPosition[4] = new Vector3(-20f, 0f, -4.5f);
		} else if (randNum == 2) {
			finalPosition[0] = new Vector3(-47.5f,0,42.7f);
			finalPosition[1] = new Vector3(-28.3f, 0f, 18f);
			finalPosition[2] = new Vector3(-9.4f, 0f, 4f);
			finalPosition[3] = new Vector3(13.3f, 0f, -6.9f);
			finalPosition[4] = new Vector3(31.6f, 0f, -28.8f);
		} else {
			finalPosition[0] = new Vector3(58f,0,47.4f);
			finalPosition[1] = new Vector3(27f, 0f, 27.4f);
			finalPosition[2] = new Vector3(-4.1f, 0f, 9f);
			finalPosition[3] = new Vector3(-20.3f, 0f, -10f);
			finalPosition[4] = new Vector3(-47.8f, 0f, -34.9f);
		}


    	//First dolphin
    	Color finalColor = new Color((4f/256f), (30f/256f), (66f/256f), 1.0f);    	
    	GameObject parentObj1 = new GameObject("Fish 1");
    	finType = finNumArray[updatedSeed1F];
    	bodyType = bodyArray[updatedSeed1B];
    	tailType = tailArray[updatedSeed1T];
    	eyeType = eyeArray[updatedSeed1E];    	
    	finalFish(parentObj1, finType, bodyType, tailType, eyeType, finalColor);
    	parentObj1.transform.position = finalPosition[0];
    	if (bodyType == tailType) {
    		parentObj1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    	}
    	
    	//Second dolphin
    	finalColor = new Color((0f/256f), (142f/256f), (151f/256f), 1.0f);
    	GameObject parentObj2 = new GameObject("Fish 2");
    	finType = finNumArray[updatedSeed2F];
    	bodyType = bodyArray[updatedSeed2B];
    	tailType = tailArray[updatedSeed2T]; 
    	eyeType = eyeArray[updatedSeed2E];   	
    	finalFish(parentObj2, finType, bodyType, tailType, eyeType, finalColor);
    	parentObj2.transform.position = finalPosition[1];
    	if (finType == tailType) {
    		parentObj2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    	}
    	
    	//Third dolphin
    	finalColor = new Color((245f/256f), (130f/256f), (32f/256f), 1.0f);
    	GameObject parentObj3 = new GameObject("Fish 3");
    	finType = finNumArray[updatedSeed3F];
    	bodyType = bodyArray[updatedSeed3B];
    	tailType = tailArray[updatedSeed3T]; 
    	eyeType = eyeArray[updatedSeed3E];   	
    	finalFish(parentObj3, finType, bodyType, tailType, eyeType, finalColor);
    	parentObj3.transform.position = finalPosition[2];
    	if (bodyType == tailType) {
    		parentObj3.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    	}

    	//Fourth dolphin
    	finalColor = new Color((130f/256f), (142f/256f), (132f/256f), 1.0f);
    	GameObject parentObj4 = new GameObject("Fish 4");
    	finType = finNumArray[updatedSeed4F];
    	bodyType = bodyArray[updatedSeed4B];
    	tailType = tailArray[updatedSeed4T];
    	eyeType = eyeArray[updatedSeed4E];    	
    	finalFish(parentObj4, finType, bodyType, tailType, eyeType, finalColor);
    	parentObj4.transform.position = finalPosition[3];
    	if (finType == "ZERO") {
    		parentObj4.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
    	}

    	//Fifth dolphin
    	finalColor = new Color((252f/256f), (76f/256f), (2f/256f), 1.0f);
    	GameObject parentObj5 = new GameObject("Fish 5");
    	finType = finNumArray[updatedSeed5F];
    	bodyType = bodyArray[updatedSeed5B];
    	tailType = tailArray[updatedSeed5T]; 
    	eyeType = eyeArray[updatedSeed5E];   	
    	finalFish(parentObj5, finType, bodyType, tailType, eyeType, finalColor);
    	parentObj5.transform.position = finalPosition[4];


		// //Test dolphin
  //   	Color finalColor = new Color((4f/256f), (30f/256f), (66f/256f), 1.0f);    	
  //   	GameObject parentObj1 = new GameObject("Fish 1");
  //   	eyeType = "ONE";
  //   	finType = "THREE";
  //   	bodyType = "THREE";
  //   	tailType = "THREE";    	
  //   	finalFish(parentObj1, finType, bodyType, tailType, eyeType, finalColor);
  //   	parentObj1.transform.position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update() {
        
    }

    GameObject create_body(Vector3 p, Vector3 r, Vector3 s, Color fishColor) {
    	ntris = 0;
    	cylinderList = new List<Vector3>();
	    TcylinderList = new List<Vector3>();
	    FcylinderList = new List<Vector3>();
	    midPointList = new List<Vector3>();

    	positions = new Vector3[(numPoints + 1) * 2];

    	vertexListLength = 9;
		triangleListLength = 24;

		vertexList = new Vector3[vertexListLength];
    	triangleList = new int[triangleListLength];

    	radiusTrack = 0;


    	//BODY
    	bezierCurveBody();
    	int counter = -1;
    	int secondCounter = 0;
    	int track = numPoints + numPointsM + 2; 
    	quad = "BODY"; 
    	

    	upper = new Vector3[track];    	
    	lower = new Vector3[track];

   		foreach(Vector3 cy in cylinderList) { 
   			counter++;
   			if (counter < track) {
   				upper[counter] = cy;
	   		} 
	   		if (counter >= track) {	
	   			lower[secondCounter] = cy;
	   			secondCounter++;
   			}   			
   		}

   		calculateMidpoint(upper, lower, track);
   		foreach (Vector3 m in midPointList) {
	    	createCylinder(m);	 
	    	vertexListLength += 9;
   			triangleListLength += (24 * 3); 
   			radiusTrack++; 
   		}

   		//CREATING MESH
   		Mesh cylinder_mesh = new Mesh();    		
    	GameObject c = new GameObject("Body");
		c.AddComponent<MeshFilter>();
		c.AddComponent<MeshRenderer>();	
		c.GetComponent<MeshFilter>().mesh = cylinder_mesh; 

		// change the color of the object
		Renderer rend = c.GetComponent<Renderer>();
		rend.material.color = fishColor;	
		
		c.GetComponent<MeshFilter>().mesh.vertices = vertexList;
		c.GetComponent<MeshFilter>().mesh.triangles = triangleList;
		c.GetComponent<MeshFilter>().mesh.RecalculateNormals();
		c.transform.position = p;
		c.transform.rotation = Quaternion.Euler(r);
		c.transform.localScale = s;
		return c;
    }

    GameObject create_tail(Vector3 p, Vector3 r, Vector3 s, Color fishColor) {
    	ntris = 0;
    	cylinderList = new List<Vector3>();
	    TcylinderList = new List<Vector3>();
	    FcylinderList = new List<Vector3>();
	    midPointList = new List<Vector3>();

    	positions = new Vector3[(numPoints + 1) * 2];

    	vertexListLength = 9;
		triangleListLength = 24;

		vertexList = new Vector3[vertexListLength];
    	triangleList = new int[triangleListLength];

    	radiusTrack = 0;

    	//TAIL
   		tailCheck = true;
   		radiusTrack = 0;
   		midPointList = new List<Vector3>();
   		int counter = -1;
   		int secondCounter = 0;
   		int track = numPoints + 1;
   		upper = new Vector3[track];    	
    	lower = new Vector3[track];
   		bezierCurveTail();
   		quad = "TAIL";

    	foreach(Vector3 cy in TcylinderList) { 
   			counter++;
   			if (counter < track) {
   				upper[counter] = cy; 
	   		} 	   		
	   		if (counter >= track) {	
	   			lower[secondCounter] = cy;
	   			secondCounter++;	   			   		
   			}   			
   		}

		calculateMidpoint(upper, lower, track);
		int center = 0;
		foreach (Vector3 mid in midPointList) {    				   							
			center++;
			if (((numPoints + 1) / 2) == center) {
				tailCheck = false;
			}
	    	createCylinder(mid);	 
	    	vertexListLength += 9;
			triangleListLength += (24 * 3); 
			radiusTrack++; 
		}
		
   		//CREATING MESH
   		Mesh cylinder_mesh = new Mesh();    		
    	GameObject c = new GameObject("Tail");
		c.AddComponent<MeshFilter>();
		c.AddComponent<MeshRenderer>();	
		c.GetComponent<MeshFilter>().mesh = cylinder_mesh; 

		// change the color of the object
		Renderer rend = c.GetComponent<Renderer>();
		rend.material.color = fishColor;	
		
		c.GetComponent<MeshFilter>().mesh.vertices = vertexList;
		c.GetComponent<MeshFilter>().mesh.triangles = triangleList;
		c.GetComponent<MeshFilter>().mesh.RecalculateNormals();
		c.transform.position = p;
		c.transform.rotation = Quaternion.Euler(r);
		c.transform.localScale = s;

		return c;
    }

    GameObject create_fin(Vector3 p, Vector3 r, Vector3 s, Color fishColor) {
    	ntris = 0;
    	cylinderList = new List<Vector3>();
	    TcylinderList = new List<Vector3>();
	    FcylinderList = new List<Vector3>();
	    midPointList = new List<Vector3>();

    	positions = new Vector3[(numPoints + 1) * 2];

    	vertexListLength = 9;
		triangleListLength = 24;

		vertexList = new Vector3[vertexListLength];
    	triangleList = new int[triangleListLength];

    	radiusTrack = 0;

    	//FIN
   		radiusTrack = 0;
   		midPointList = new List<Vector3>();
   		int counter = -1;
   		int secondCounter = 0;
   		int track = numPoints + 1;
   		upper = new Vector3[track];    	
    	lower = new Vector3[track];
   		bezierCurveFin();
   		quad = "FIN";

    	foreach(Vector3 cy in FcylinderList) { 
   			counter++;
   			if (counter < track) {
   				upper[counter] = cy;    		
	   		} 	   		
	   		if (counter >= track) {	
	   			lower[secondCounter] = cy;
	   			secondCounter++;	   			   		
   			}   			
   		}

		calculateMidpoint(upper, lower, track);
		
		foreach (Vector3 mid in midPointList) {		
	    	createCylinder(mid);	 
	    	vertexListLength += 9;
			triangleListLength += (24 * 3); 
			radiusTrack++; 
		}
		
   		//CREATING MESH
   		Mesh cylinder_mesh = new Mesh();    		
    	GameObject c = new GameObject("Fin");
		c.AddComponent<MeshFilter>();
		c.AddComponent<MeshRenderer>();	
		c.GetComponent<MeshFilter>().mesh = cylinder_mesh; 

		// change the color of the object
		Renderer rend = c.GetComponent<Renderer>();
		rend.material.color = fishColor;	
		
		c.GetComponent<MeshFilter>().mesh.vertices = vertexList;
		c.GetComponent<MeshFilter>().mesh.triangles = triangleList;
		c.GetComponent<MeshFilter>().mesh.RecalculateNormals();
		c.transform.position = p;
		c.transform.rotation = Quaternion.Euler(r);
		c.transform.localScale = s;

		return c;
    }

    void bezierCurveBody() {
    	//upper body curve
    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / ((float)numPoints);
    		positions[i] = caculateBezierPoint(t, point1.position, point2.position, point3.position, point4.position); 
    		
    		cylinderList.Add(positions[i]);   		
    	 }

    	 //upper mouth curve
    	 for (int i = 0; i <= numPointsM; i++) {
    		float t = i / (float)numPointsM;
    		
    		positions[i] = caculateBezierPoint(t, Umouthp1.position, Umouthc1.position, Umouthc2.position, Umouthp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		cylinderList.Add(positions[i]);
    	}

    	//lower body curve
    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / (float)numPoints;
    		positions[i] = caculateBezierPoint(t, point5.position, point6.position, point7.position, point8.position);     		
    		
    		//Debug.Log(positions[i]);
    		cylinderList.Add(positions[i]);
    	}

    	//lower mouth curve
    	 for (int i = 0; i <= numPointsM; i++) {
    		float t = i / (float)numPointsM;
    		positions[i] = caculateBezierPoint(t, Lmouthp1.position, Lmouthc1.position, Lmouthc2.position, Lmouthp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		cylinderList.Add(positions[i]);       	
    	} 		 		
    }

    void bezierCurveTail() {
    	//upper tail
    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / (float)numPoints;
    		positions[i] = caculateBezierPoint(t, tailp1.position, tailc1.position, tailc2.position, tailp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		TcylinderList.Add(positions[i]);       	
    	}

    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / (float)numPoints;
    		positions[i] = caculateBezierPoint(t, Ltailp1.position, Ltailc1.position, Ltailc2.position, Ltailp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		TcylinderList.Add(positions[i]);    		       
    	}
    }

    void bezierCurveFin() {
    	//upper tail
    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / (float)numPoints;
    		positions[i] = caculateBezierPoint(t, Ufinp1.position, Ufinc1.position, Ufinc2.position, Ufinp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		FcylinderList.Add(positions[i]);       	
    	}

    	for (int i = 0; i <= numPoints; i++) {
    		float t = i / (float)numPoints;
    		positions[i] = caculateBezierPoint(t, Lfinp1.position, Lfinc1.position, Lfinc2.position, Lfinp2.position);     		
    		
    		//Debug.Log(positions[i]);
    		FcylinderList.Add(positions[i]);    		       
    	}
    }

    Vector3 caculateBezierPoint(float t, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4){

    	float b1 = ((1-t) * (1-t) * (1-t));
    	float b2 = (3 * t * ((1-t) * (1-t)));
    	float b3 = (3 * t * t * (1-t));
    	float b4 = (t * t * t);

    	Vector3 q = (b1 * p1) + (b2 * p2) + (b3 * p3) + (b4 * p4);
    	return q;
    }

    void calculateMidpoint(Vector3[] upper, Vector3[] lower, int track) {    	
    	for (int i = 0; i < track; i++) {    		
    		Vector3 midpoint = new Vector3(0,0,0);
		    midpoint.x = (upper[i].x + lower[i].x) / 2.0f;
		    midpoint.y = (upper[i].y + lower[i].y) / 2.0f;
		    midpoint.z = (upper[i].z + lower[i].z) / 2.0f;
		    midPointList.Add(midpoint);			    
    	}
    	
    }

    void createCylinder(Vector3 position) {
    	Vector3[] newVertexList = new Vector3[vertexListLength];
    	for (int i = 0; i < vertexList.Length; i++) {
			newVertexList[i] = vertexList[i];
		}
		vertexList = newVertexList;


		int[] newTriangleList = new int[(triangleListLength) + (24 * 3)];
		for (int i = 0; i < triangleList.Length; i++) {
			newTriangleList[i] = triangleList[i];
		}
		triangleList = newTriangleList;

		index = vertexListLength - 1;
		// print("Index: " + index);	
		
		int zero = index - 8;
		int one = index - 7;
		int two = index - 6;
		int three = index - 5;
		int four = index - 4;
		int five = index - 3;
		int six = index - 2;
		int seven = index - 1;
		int eight = index - 0;

		int sub = 9;
		int prevZero = zero - sub;
		int prevOne = one - sub;
    	int prevTwo = two - sub;
    	int prevThree = three - sub;
    	int prevFour = four - sub;
    	int prevFive = five - sub;
    	int prevSix = six - sub;
    	int prevSeven = seven - sub;
    	int prevEight = eight - sub;


		//update Radius
		radius = calculateRadius(position, upper[radiusTrack]);
		calculateOctagonPoints(index, position);

		if (quad == "BODY") {
			int bodyIndex = ((numPoints + 1) * 9) - 1;
	
			if (bodyType == "ONE") {
				if ((index <= 8) || ((index > bodyIndex) && (index <= (bodyIndex + 9)))) {
					MakeTri(two,one,zero);
			    	MakeTri(three,two,zero);
			    	MakeTri(four,three,zero);
			    	MakeTri(five,four,zero);
			    	MakeTri(six,five,zero);
			    	MakeTri(seven,six,zero);
			    	MakeTri(eight,seven,zero);
			    	MakeTri(one,eight,zero);
				} else {
					//if error occurs then check this +45
					if (index == bodyIndex + 45) {
						MakeTri(two,one,zero);
				    	MakeTri(three,two,zero);
				    	MakeTri(four,three,zero);
				    	MakeTri(five,four,zero);
				    	MakeTri(six,five,zero);
				    	MakeTri(seven,six,zero);
				    	MakeTri(eight,seven,zero);
				    	MakeTri(one,eight,zero);
					} else {
						MakeTri(zero,one,two);
				    	MakeTri(zero,two,three);
				    	MakeTri(zero,three,four);
				    	MakeTri(zero,four,five);
				    	MakeTri(zero,five,six);
				    	MakeTri(zero,six,seven);
				    	MakeTri(zero,seven,eight);
				    	MakeTri(zero,eight,one);
					}					

			    	if (index > bodyIndex) {
			    		MakeQuad(one,two,prevTwo,prevOne);
				    	MakeQuad(two,three,prevThree,prevTwo);
				    	MakeQuad(three,four,prevFour,prevThree);
				    	MakeQuad(four,five,prevFive,prevFour);
				    	MakeQuad(five,six,prevSix,prevFive);
				    	MakeQuad(six,seven,prevSeven,prevSix);
				    	MakeQuad(seven,eight,prevEight,prevSeven);
				    	MakeQuad(eight,one,prevOne,prevEight);
		    		} else { 
		    			MakeQuad(two,one,prevOne,prevTwo);
				    	MakeQuad(three,two,prevTwo,prevThree);
				    	MakeQuad(four,three,prevThree,prevFour);
				    	MakeQuad(five,four,prevFour,prevFive);
				    	MakeQuad(six,five,prevFive,prevSix);
				    	MakeQuad(seven,six,prevSix,prevSeven);
				    	MakeQuad(eight,seven,prevSeven,prevEight);
				    	MakeQuad(one,eight,prevEight,prevOne);
		    		}
		    		
					
				}
			} else if (bodyType == "TWO") {
				if ((index <= 8)) {
					MakeTri(two,one,zero);
			    	MakeTri(three,two,zero);
			    	MakeTri(four,three,zero);
			    	MakeTri(five,four,zero);
			    	MakeTri(six,five,zero);
			    	MakeTri(seven,six,zero);
			    	MakeTri(eight,seven,zero);
			    	MakeTri(one,eight,zero);
				} else {
					MakeTri(zero,one,two);
			    	MakeTri(zero,two,three);
			    	MakeTri(zero,three,four);
			    	MakeTri(zero,four,five);
			    	MakeTri(zero,five,six);
			    	MakeTri(zero,six,seven);
			    	MakeTri(zero,seven,eight);
			    	MakeTri(zero,eight,one);

		    		MakeQuad(two,one,prevOne,prevTwo);
			    	MakeQuad(three,two,prevTwo,prevThree);
			    	MakeQuad(four,three,prevThree,prevFour);
			    	MakeQuad(five,four,prevFour,prevFive);
			    	MakeQuad(six,five,prevFive,prevSix);
			    	MakeQuad(seven,six,prevSix,prevSeven);
			    	MakeQuad(eight,seven,prevSeven,prevEight);
			    	MakeQuad(one,eight,prevEight,prevOne);
					
				}
			} else {   //bodyType == THREE
				if ((index <= 8) || ((index > bodyIndex) && (index <= (bodyIndex + 9)))) {
					MakeTri(two,one,zero);
			    	MakeTri(three,two,zero);
			    	MakeTri(four,three,zero);
			    	MakeTri(five,four,zero);
			    	MakeTri(six,five,zero);
			    	MakeTri(seven,six,zero);
			    	MakeTri(eight,seven,zero);
			    	MakeTri(one,eight,zero);
				} else {					
		    		if (index > bodyIndex) {
		    			MakeTri(two,one,zero);
				    	MakeTri(three,two,zero);
				    	MakeTri(four,three,zero);
				    	MakeTri(five,four,zero);
				    	MakeTri(six,five,zero);
				    	MakeTri(seven,six,zero);
				    	MakeTri(eight,seven,zero);
				    	MakeTri(one,eight,zero);

			    		MakeQuad(one,two,prevTwo,prevOne);
				    	MakeQuad(two,three,prevThree,prevTwo);
				    	MakeQuad(three,four,prevFour,prevThree);
				    	MakeQuad(four,five,prevFive,prevFour);
				    	MakeQuad(five,six,prevSix,prevFive);
				    	MakeQuad(six,seven,prevSeven,prevSix);
				    	MakeQuad(seven,eight,prevEight,prevSeven);
				    	MakeQuad(eight,one,prevOne,prevEight);

		    		} else { 
	    				MakeTri(zero,one,two);
				    	MakeTri(zero,two,three);
				    	MakeTri(zero,three,four);
				    	MakeTri(zero,four,five);
				    	MakeTri(zero,five,six);
				    	MakeTri(zero,six,seven);
				    	MakeTri(zero,seven,eight);
				    	MakeTri(zero,eight,one);

		    			MakeQuad(two,one,prevOne,prevTwo);
				    	MakeQuad(three,two,prevTwo,prevThree);
				    	MakeQuad(four,three,prevThree,prevFour);
				    	MakeQuad(five,four,prevFour,prevFive);
				    	MakeQuad(six,five,prevFive,prevSix);
				    	MakeQuad(seven,six,prevSix,prevSeven);
				    	MakeQuad(eight,seven,prevSeven,prevEight);
				    	MakeQuad(one,eight,prevEight,prevOne);
		    		 }
					
				}
			}
			
		}

		if (quad == "TAIL") {
			if (tailType == "ONE") {			
				if(index <= 8) {
					MakeTri(zero,one,two);
			    	MakeTri(zero,two,three);
			    	MakeTri(zero,three,four);
			    	MakeTri(zero,four,five);
			    	MakeTri(zero,five,six);
			    	MakeTri(zero,six,seven);
			    	MakeTri(zero,seven,eight);
			    	MakeTri(zero,eight,one);
				} else {
					
					MakeTri(two,one,zero);
			    	MakeTri(three,two,zero);
			    	MakeTri(four,three,zero);
			    	MakeTri(five,four,zero);
			    	MakeTri(six,five,zero);
			    	MakeTri(seven,six,zero);
			    	MakeTri(eight,seven,zero);
			    	MakeTri(one,eight,zero);

		    	    MakeQuad(one,two,prevTwo,prevOne);
			    	MakeQuad(two,three,prevThree,prevTwo);
			    	MakeQuad(three,four,prevFour,prevThree);
			    	MakeQuad(four,five,prevFive,prevFour);
			    	MakeQuad(five,six,prevSix,prevFive);
			    	MakeQuad(six,seven,prevSeven,prevSix);
			    	MakeQuad(seven,eight,prevEight,prevSeven);
			    	MakeQuad(eight,one,prevOne,prevEight);			
										
				}
			}
			
			if (tailType == "TWO") {			
				if(index <= 8) {
					MakeTri(zero,one,two);
			    	MakeTri(zero,two,three);
			    	MakeTri(zero,three,four);
			    	MakeTri(zero,four,five);
			    	MakeTri(zero,five,six);
			    	MakeTri(zero,six,seven);
			    	MakeTri(zero,seven,eight);
			    	MakeTri(zero,eight,one);
				} else {
					MakeTri(two,one,zero);
			    	MakeTri(three,two,zero);
			    	MakeTri(four,three,zero);
			    	MakeTri(five,four,zero);
			    	MakeTri(six,five,zero);
			    	MakeTri(seven,six,zero);
			    	MakeTri(eight,seven,zero);
			    	MakeTri(one,eight,zero);

			    	MakeQuad(one,two,prevTwo,prevOne);
			    	MakeQuad(two,three,prevThree,prevTwo);
			    	MakeQuad(three,four,prevFour,prevThree);
			    	MakeQuad(four,five,prevFive,prevFour);
			    	MakeQuad(five,six,prevSix,prevFive);
			    	MakeQuad(six,seven,prevSeven,prevSix);
			    	MakeQuad(seven,eight,prevEight,prevSeven);
			    	MakeQuad(eight,one,prevOne,prevEight);

				}
			}

			if (tailType == "THREE") {		
				if(index <= 8) {
					MakeTri(zero,one,two);
			    	MakeTri(zero,two,three);
			    	MakeTri(zero,three,four);
			    	MakeTri(zero,four,five);
			    	MakeTri(zero,five,six);
			    	MakeTri(zero,six,seven);
			    	MakeTri(zero,seven,eight);
			    	MakeTri(zero,eight,one);
				} else {

					if (index >= 278) {
						MakeTri(two,one,zero);
				    	MakeTri(three,two,zero);
				    	MakeTri(four,three,zero);
				    	MakeTri(five,four,zero);
				    	MakeTri(six,five,zero);
				    	MakeTri(seven,six,zero);
				    	MakeTri(eight,seven,zero);
				    	MakeTri(one,eight,zero);
					} else {
						MakeTri(zero,one,two);
				    	MakeTri(zero,two,three);
				    	MakeTri(zero,three,four);
				    	MakeTri(zero,four,five);
				    	MakeTri(zero,five,six);
				    	MakeTri(zero,six,seven);
				    	MakeTri(zero,seven,eight);
				    	MakeTri(zero,eight,one);
					}
					

			    	MakeQuad(one,two,prevTwo,prevOne);
			    	MakeQuad(two,three,prevThree,prevTwo);
			    	MakeQuad(three,four,prevFour,prevThree);
			    	MakeQuad(four,five,prevFive,prevFour);
			    	MakeQuad(five,six,prevSix,prevFive);
			    	MakeQuad(six,seven,prevSeven,prevSix);
			    	MakeQuad(seven,eight,prevEight,prevSeven);
			    	MakeQuad(eight,one,prevOne,prevEight);

				}
			}
		}


		if (quad == "FIN") {
			if (index <= 8) {				
				MakeTri(two,one,zero);
		    	MakeTri(three,two,zero);
		    	MakeTri(four,three,zero);
		    	MakeTri(five,four,zero);
		    	MakeTri(six,five,zero);
		    	MakeTri(seven,six,zero);
		    	MakeTri(eight,seven,zero);
		    	MakeTri(one,eight,zero);
			} else {
				MakeTri(zero,one,two);
		    	MakeTri(zero,two,three);
		    	MakeTri(zero,three,four);
		    	MakeTri(zero,four,five);
		    	MakeTri(zero,five,six);
		    	MakeTri(zero,six,seven);
		    	MakeTri(zero,seven,eight);
		    	MakeTri(zero,eight,one);

	    		MakeQuad(two,one,prevOne,prevTwo);
		    	MakeQuad(three,two,prevTwo,prevThree);
		    	MakeQuad(four,three,prevThree,prevFour);
		    	MakeQuad(five,four,prevFour,prevFive);
		    	MakeQuad(six,five,prevFive,prevSix);
		    	MakeQuad(seven,six,prevSix,prevSeven);
		    	MakeQuad(eight,seven,prevSeven,prevEight);
		    	MakeQuad(one,eight,prevEight,prevOne);
			}
		}
	  
    }

    float calculateRadius(Vector3 midPosition, Vector3 upperPosition){     	
	    float newRadius = Vector3.Distance(upperPosition, midPosition);
    	return newRadius;
    }

    void calculateOctagonPoints(int index, Vector3 position) {
    	Vector3 R = new Vector3(1,1,1);
    	//Vector3 D = new Vector3(0,-1,0);

    	T = new Vector3(position.x, position.y, position.z).normalized;   
    	if ((quad == "BODY")) {
    		T = Quaternion.Euler(0, 90, 0) * T;
    	}

    	// if ((tailType == "ONE")) {
    	// 	T = Quaternion.Euler(0,90,0) * T;
    	// }
    	// if (tailType == "TWO") {
    	// 	T = Quaternion.Euler(0, 45, 0) * T;
    	// }
    	
    	if ((quad == "FIN")) {
    		T = Quaternion.Euler(0, 145, 0) * T;
    	}

    	T = T.normalized;	
    	N = Vector3.Cross(T,R).normalized;
    	B = Vector3.Cross(T, N).normalized;


    	int zero = index - 8;
		int one = index - 7;
		int two = index - 6;
		int three = index - 5;
		int four = index - 4;
		int five = index - 3;
		int six = index - 2;
		int seven = index - 1;
		int eight = index - 0;

    	vertexList[zero] = new Vector3(position.x, position.y, position.z);

	    float baseAngle = 45f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int one = index - 7;
	   	float x = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[one] = new Vector3(x,y,z);
    	

	    baseAngle = 90f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int two = index - 6;
	   	float x1 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y1 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z1 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;    	
	   	vertexList[two] = new Vector3(x1,y1,z1);


	    baseAngle = 135f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int three = index - 5;
	   	float x2 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y2 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z2 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[three] = new Vector3(x2,y2,z2);	    	

	    baseAngle = 180f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int four = index - 4;
	   	float x3 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	  	float y3 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
    	float z3 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;	    
    	vertexList[four] = new Vector3(x3,y3,z3);

	    baseAngle = 225f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int five = index - 3;
	   	float x4 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y4 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z4 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[five] = new Vector3(x4,y4,z4);

	    baseAngle = 270f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int six = index - 2;
	   	float x5 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y5 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z5 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[six] = new Vector3(x5,y5,z5);

	    baseAngle = 315f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int seven = index - 1;
	  	float x6 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y6 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z6 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[seven] = new Vector3(x6,y6,z6);
	 
	    baseAngle = 360f;
	   	baseAngle = baseAngle * Mathf.Deg2Rad;
	   	// int eight = index - 0;
	   	float x7 = ((((N.x) * Mathf.Cos(baseAngle)) * radius) + (((B.x) * Mathf.Sin(baseAngle)) * radius)) + position.x;
	   	float y7 = ((((N.y) * Mathf.Cos(baseAngle)) * radius) + (((B.y) * Mathf.Sin(baseAngle)) * radius)) + position.y;
	   	float z7 = ((((N.z) * Mathf.Cos(baseAngle)) * radius) + (((B.z) * Mathf.Sin(baseAngle)) * radius)) + position.z;
    	vertexList[eight] = new Vector3(x7,y7,z7);
    }

    void MakeTri(int i1, int i2, int i3) {
		int triIndex = ntris * 3;  
		ntris++;

		triangleList[triIndex]     = i1;
		triangleList[triIndex + 1] = i2;
		triangleList[triIndex + 2] = i3;
	}

	// make a quadrilateral from four vertex indices (clockwise order)
	void MakeQuad(int i1, int i2, int i3, int i4) {
		MakeTri (i1, i2, i3);
		MakeTri (i1, i3, i4);
	}

	void calculateBodyPoints() {
		if (bodyType == "ONE") {
			point1.position = new Vector3(0.01f,0f,5.01f);    	
			point2.position = new Vector3(5.87f, 0f, 9.73f);
			point3.position = new Vector3(8.13f,0f,2.65f);
			point4.position = new Vector3(11.74f,0f,4.4f);
			 
			point5.position = new Vector3(-0.01f,0f,4.77f);
			point6.position = new Vector3(3.96f,0f,1.68f); 
			point7.position = new Vector3(6.22f,0f,1.38f);    	
			point8.position = new Vector3(11.74f,0f,4.4f);

			Umouthp1.position = new Vector3(0.01f,0f,5.01f);   //4   	
			Umouthc1.position = new Vector3(-0.176f,0f,5.06f);
			Umouthc2.position = new Vector3(-0.27f,0f,5.09f);    	
			Umouthp2.position = new Vector3(-0.385f,0f,5.01f);

			Lmouthp1.position = new Vector3(-0.01f,0f,4.77f);   //8
			Lmouthc1.position = new Vector3(-0.21f,0f,4.68f);
			Lmouthc2.position = new Vector3(-0.29f,0f,4.694f);    	
			Lmouthp2.position = new Vector3(-0.385f,0f,4.755f);

		}

		if (bodyType == "TWO") {
			point1.position = new Vector3(-3.4f,0f,4.57f);    	
			point2.position = new Vector3(-1.4f, 0f, 6.16f);
			point3.position = new Vector3(3.4f,0f,13.96f);
			point4.position = new Vector3(11.6f,0f,6.7f);
			 
			point5.position = new Vector3(-2.5f,0f,3.43f);
			point6.position = new Vector3(2.37f,0f,8.2f); 
			point7.position = new Vector3(4.14f,0f,4.16f);    	
			point8.position = new Vector3(11.13f,0f,5.4f);

			Umouthp1.position = point4.position;   	
			Umouthc1.position = new Vector3(12.8f,0f,5.82f);
			Umouthc2.position = new Vector3(13.76f,0f,5.79f);    	
			Umouthp2.position = new Vector3(13.95f,0f,5.27f);

			Lmouthp1.position = point8.position;   	
			Lmouthc1.position = new Vector3(12.42f,0f,5.36f);
			Lmouthc2.position = new Vector3(13.78f,0f,5.35f);    	
			Lmouthp2.position = new Vector3(13.95f,0f,5.27f);

		}
		
		if (bodyType == "THREE") {
			point1.position = new Vector3(-1.2f,0f,12.36f);    	
			point2.position = new Vector3(2.8f, 0f, 18f);
			point3.position = new Vector3(11.4f,0f,9.97f);
			// point4.position = new Vector3(1.32f,0f,0.39f);
			point4.position = new Vector3(3.11f,0f,0.25f);
			 
			point5.position = new Vector3(-1.15f,0f,10.6f);
			point6.position = new Vector3(2.03f,0f,7.3f); 
			point7.position = new Vector3(2f,0f,5.2f);    	
			// point8.position = new Vector3(4.72f,0f,0.01f);
			point8.position = new Vector3(0.07f,0f,0.08f);

			Umouthp1.position = new Vector3(-1.25f,0f,12.2f);   	
			Umouthc1.position = new Vector3(-1.45f,0f,12.4f);
			Umouthc2.position = new Vector3(-1.92f,0f,12.26f);    	
			Umouthp2.position = new Vector3(-2.3f,0f,11.8f);

			Lmouthp1.position = new Vector3(-1.12f,0f,10.6f);   	
			Lmouthc1.position = new Vector3(-1.92f,0f,11f);
			Lmouthc2.position = new Vector3(-1.25f,0f,11.55f);    	
			Lmouthp2.position = new Vector3(-2.2f,0f,11.5f);

			tailp1.position = new Vector3(-0.96f,0f,0.31f);
			tailp2.position = new Vector3(4.82f,0f,-0.34f);   							    	
			tailc1.position = new Vector3(1.39f,0f,0.38f);
			tailc2.position = new Vector3(3.35f,0f,0.38f);

			Ltailp1.position = new Vector3(-1f,0f,-0.9f);
			Ltailp2.position = new Vector3(4.76f,0f,-0.9f);
			Ltailc1.position = new Vector3(0.78f,0f,-1.9f);   				
			Ltailc2.position = new Vector3(2.74f,0f,-1.9f);    	
			
		}

		if (tailType == "ONE") {
			
			tailp1.position = new Vector3(-7.82f,0f,5.78f);   	
			tailp2.position = new Vector3(-2.12f,0f,-0.88f);
			tailc1.position = new Vector3(0.32f,0f,5.51f);    	
			tailc2.position = new Vector3(-1.37f,0f,5.55f);

			Ltailp1.position = new Vector3(-7.82f,0f,5.78f);
			// Ltailp1.position = new Vector3(-8.05f,0f,5.41f);   	
			// Ltailp2.position = new Vector3(-3.8f,0f,-0.88f);
			Ltailp2.position = new Vector3(-2.12f,0f,-0.88f);
			Ltailc1.position = new Vector3(-3.14f,0f,4.27f);    	
			Ltailc2.position = new Vector3(-3.8f,0f,3.61f);
		}

		if (tailType == "TWO") {
			tailp1.position = new Vector3(-7.82f,0f,5.8f);   	
			tailp2.position = new Vector3(-3.77f,0f,0.52f);
			tailc1.position = new Vector3(0.32f,0f,5.51f);    	
			tailc2.position = new Vector3(-1.37f,0f,5.55f);

			Ltailp1.position = new Vector3(-8.05f,0f,5.41f);   	
			Ltailp2.position = new Vector3(-4.27f,0f,0.43f);
			Ltailc1.position = new Vector3(-8.83f,0f,1.87f);    	
			Ltailc2.position = new Vector3(-8.5f,0f,1.1f);
		}

		if (tailType == "THREE") {
			tailp1.position = new Vector3(-7.54f,0f,5.78f);   	
			tailp2.position = new Vector3(-3.36f,0f,-0.494f);
			tailc1.position = new Vector3(-5.5f,0f,4.1f);    	
			tailc2.position = new Vector3(-6.24f,0f,3.46f);

			Ltailp1.position = new Vector3(-8.02f,0f,5.7f);   	
			Ltailp2.position = new Vector3(-3.86f,0f,-1.02f);
			Ltailc1.position = new Vector3(-11.8f,0f,1.2f);    	
			Ltailc2.position = new Vector3(-11.94f,0f,0.24f);
		}

		
		Ufinp1.position = new Vector3(3.37f,0f,11.71f);   	
		Ufinp2.position = new Vector3(5.71f,0f,9.32f);
		Ufinc1.position = new Vector3(4.44f,0f,11.49f);    	
		Ufinc2.position = new Vector3(6.18f,0f,10.66f);
		   	
		Lfinp1.position = new Vector3(3.33f,0f,11.9f);
		Lfinp2.position = new Vector3(3.22f,0f,9.06f);
		Lfinc1.position = new Vector3(3.37f,0f,11.53f);
		Lfinc2.position = new Vector3(3.84f,0f,10.2f);
		

    	//Can use it for fin
    	// Ufinp1.position = new Vector3(3.8f,0f,12.3f);   	
    	// Ufinp2.position = new Vector3(5.43f,0f,9.75f);
    	// Ufinc1.position = new Vector3(4.44f,0f,11.49f);    	
    	// Ufinc2.position = new Vector3(5.25f,0f,11.25f);
    	   	
    	// Lfinp1.position = new Vector3(3.1f,0f,11.9f);
    	// Lfinp2.position = new Vector3(3.18f,0f,9.5f);
    	// Lfinc1.position = new Vector3(3.37f,0f,11.53f);
    	// Lfinc2.position = new Vector3(3.84f,0f,11.8f);
	}

	void finalFish(GameObject parentObj, string finType, string bodyType, string tailType, string eyeType, Color finalColor) {
		GameObject body;    	
    	GameObject tail;
    	GameObject leftEye;
    	GameObject rightEye;

    	calculateBodyPoints();

    	if (eyeType == "ONE") {
	        if (finType == "ZERO") {
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);

	    				rotate = new Vector3(-27.355f, 0f, 0f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        location = new Vector3(12.1f, 2.56f, -0.61f);
				        rotate = new Vector3(9.432f, -38.081f, 174.741f);
				        scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.69f, 1.77f, 3.95f);
				        rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
				        scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(18.33f, 0f, -1.08f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-19.7f, 1.88f, 3.83f);
				        rotate = new Vector3(-50.778f, 30.267f, -25.559f);
				        scale = new Vector3(1f, 1f, 1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
				        rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.789f, -0.49f, 1.14f);
				        rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.51f, 0f, 0f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-0.95f, 0f, -0.5f);
				    	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
				        rotate = new Vector3(-193.602f,12.96599f,-183.372f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {        //bodyType == "THREE"
	        		if (tailType == "ONE") {

	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(1.71f, 1.24f, 3.49f);
				     	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(0.79602f,0.79602f,0.79602f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.49f, -0.21f, 2.67f);
				        rotate = new Vector3(-3.461f,-54.807f,-29.341f);
				        scale = new Vector3(0.91773f,0.91773f,0.91773f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.64f, -1.05f, 5.76f);
				     	rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
				        rotate = new Vector3(9.63f,49.048f,-7.454f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.48f, 3.845f, -0.71f);
				     	rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				       location = new Vector3(-7.16f, 2.71f, -5.11f);
				        rotate = new Vector3(12.142f,-221.2f,-9.414f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        } else if (finType == "ONE") {
	        	GameObject fin1;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);

	    				rotate = new Vector3(-27.355f, 0f, 0f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        location = new Vector3(12.1f, 2.56f, -0.61f);
				        rotate = new Vector3(9.432f, -38.081f, 174.741f);
				        scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 1.58f, -4.05f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.69f, 1.77f, 3.95f);
				        rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
				        scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(18.33f, 0f, -1.08f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 2.26f, 0.15f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-19.7f, 1.88f, 3.83f);
				        rotate = new Vector3(-50.778f, 30.267f, -25.559f);
				        scale = new Vector3(1f, 1f, 1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
				        rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-18.5f, 4.11f, -2.14f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 0f, 0f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.789f, -0.49f, 1.14f);
				        rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.51f, 0f, 0f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-11.49f, 1.8f, 0.77f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-0.95f, 0f, -0.5f);
				    	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
				        rotate = new Vector3(-193.602f,12.96599f,-183.372f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 0f, 0f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(1.71f, 1.24f, 3.49f);
				     	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(0.79602f,0.79602f,0.79602f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.49f, -0.21f, 2.67f);
				        rotate = new Vector3(-3.461f,-54.807f,-29.341f);
				        scale = new Vector3(0.91773f,0.91773f,0.91773f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-2.1f, 2.7f, 17.1f);
				        rotate = new Vector3(6.576f, 102.42f, -10.861f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.64f, -1.05f, 5.76f);
				     	rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
				        rotate = new Vector3(9.63f,49.048f,-7.454f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-12.03f, 3.72f, 11.97f);
				        rotate = new Vector3(-1.599f, 40.463f, -36.884f);
				        scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.48f, 3.845f, -0.71f);
				     	rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-7.16f, 2.71f, -5.11f);
				        rotate = new Vector3(12.142f,-221.2f,-9.414f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-3.6f, 8.54f, 15.02f);
				        rotate = new Vector3(8.802f, 122.863f, -47.972f);
				        scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        }   else if (finType == "TWO") {
	        	GameObject fin1;
	        	GameObject fin2;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);

	                    rotate = new Vector3(-27.355f, 0f, 0f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    location = new Vector3(12.1f, 2.56f, -0.61f);
	                    rotate = new Vector3(9.432f, -38.081f, 174.741f);
	                    scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 1.54f, -4.18f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(2.71f, 4.03f, -4.27f);
	                    rotate = new Vector3(16.778f, 3.849f, -1.314f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.69f, 1.77f, 3.95f);
	                    rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
	                    scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(18.33f, 0f, -1.08f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 2.26f, 0.15f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-1.39f, 1.88f, 2.07f);
	                    rotate = new Vector3(0f, 35.358f, 0f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-19.7f, 1.88f, 3.83f);
	                    rotate = new Vector3(-50.778f, 30.267f, -25.559f);
	                    scale = new Vector3(1f, 1f, 1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
	                    rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-18.5f, 4.11f, -2.14f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-16.92f, 5.16f, -0.67f);
	                    rotate = new Vector3(16.78f, 10.108f, -1.101f);
	                    scale = new Vector3(0.8162609f, 0.6710809f, 0.8162609f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;           

	                    location = new Vector3(8.47f, -3.49f, 12.23f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.789f, -0.49f, 1.14f);
	                    rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.51f, 0f, 0f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-11.49f, 1.8f, 0.77f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-4.84f, -0.76f, 13.79f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-0.95f, 0f, -0.5f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
	                    rotate = new Vector3(-193.602f,12.96599f,-183.372f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(3.61f, -1.86f, 12.52f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {

	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(1.71f, 1.24f, 3.49f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(0.79602f,0.79602f,0.79602f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.49f, -0.21f, 2.67f);
	                    rotate = new Vector3(-3.461f,-54.807f,-29.341f);
	                    scale = new Vector3(0.91773f,0.91773f,0.91773f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-2.1f, 2.7f, 17.1f);
	                    rotate = new Vector3(6.576f, 102.42f, -10.861f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 3.26f, 8.85f);
	                    rotate = new Vector3(4.751f, 257.713f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.64f, -1.05f, 5.76f);
	                    rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
	                    rotate = new Vector3(9.63f,49.048f,-7.454f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    // location = new Vector3(-11.31f, 1.68f, 10.58f);
	                    // rotate = new Vector3(-1.599f, 40.463f, -36.884f);
	                    // scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    // fin1 = create_fin(location, rotate, scale, finalColor);
	                    // fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-11.31f, 3.72f, 11.97f);
	                    rotate = new Vector3(-1.599f, 40.463f, -36.884f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(0.87f, 1.47f, 11.97f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.48f, 3.845f, -0.71f);
	                    rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-7.16f, 2.71f, -5.11f);
	                    rotate = new Vector3(12.142f,-221.2f,-9.414f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.6f, 8.54f, 15.02f);
	                    rotate = new Vector3(8.802f, 122.863f, -47.972f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(6.59f, 7.08f, 5.56f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	}
	        }   else if (finType == "THREE") {
	        	GameObject fin1;
	        	GameObject fin2;
	        	GameObject fin3;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);

	                    rotate = new Vector3(-27.355f, 0f, 0f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    location = new Vector3(12.1f, 2.56f, -0.61f);
	                    rotate = new Vector3(9.432f, -38.081f, 174.741f);
	                    scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.86f, -0.58f, -3.22f);
	                    rotate = new Vector3(-3.087f, 22.315f, 20.209f);
	                    scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.78f, 8.73f, -0.26f);
	                    rotate = new Vector3(55.528f, 2.395f, -2.223f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(9.67f, -0.59f, -2.72f);
	                    rotate = new Vector3(-27.379f, -15.156f, -163.207f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.69f, 1.77f, 3.95f);
	                    rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
	                    scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(18.33f, 0f, -1.08f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.91f, 4.95f, 0.1f);
	                    rotate = new Vector3(29.106f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-1.39f, 1.88f, 2.07f);
	                    rotate = new Vector3(0f, 35.358f, 0f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(4.18f, -0.15f, 16.61f);
	                    rotate = new Vector3(-27.579f, 211.611f, -175.451f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-19.7f, 1.88f, 3.83f);
	                    rotate = new Vector3(-50.778f, 30.267f, -25.559f);
	                    scale = new Vector3(1f, 1f, 1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
	                    rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-18.5f, 4.11f, -2.14f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-19.39f, 5.58f, 1.58f);
	                    rotate = new Vector3(16.78f, 10.108f, -1.101f);
	                    scale = new Vector3(0.6056002f, 0.4978882f, 0.6056002f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.57f, -4.3f, 7.55f);
	                    rotate = new Vector3(-108.761f, 44.14099f, -52.54901f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;           

	                    location = new Vector3(5.8f, 5.42f, 7.07f);
	                    rotate = new Vector3(74.34901f, 202.613f, 237.952f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(13.61f, -6.56f, 9.9f);
	                    rotate = new Vector3(-110.18f, 39.04399f, 133.112f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.789f, -0.49f, 1.14f);
	                    rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.51f, 0f, 0f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-11.49f, 1.8f, 0.77f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-4.84f, -0.76f, 13.79f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-9.62f, 9.88f, 6.27f);
	                    rotate = new Vector3(72.62701f, 135.814f, 208.531f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-0.95f, 0f, -0.5f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
	                    rotate = new Vector3(-193.602f,12.96599f,-183.372f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(3.61f, -1.86f, 12.52f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(8.21f, 7.15f, 9.26f);
	                    rotate = new Vector3(42.911f, -152.46f, -44.454f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(1.71f, 1.24f, 3.49f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(0.79602f,0.79602f,0.79602f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.49f, -0.21f, 2.67f);
	                    rotate = new Vector3(-3.461f,-54.807f,-29.341f);
	                    scale = new Vector3(0.91773f,0.91773f,0.91773f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-2.1f, 2.7f, 17.1f);
	                    rotate = new Vector3(6.576f, 102.42f, -10.861f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(7.52f, 2.85f, 8.81f);
	                    rotate = new Vector3(29.038f, -117.783f, -34.069f);
	                    scale = new Vector3(0.4798435f, 0.3944988f, 0.4798435f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(7.61f, 6.2f, 9.26f);
	                    rotate = new Vector3(29.038f, -117.783f, -34.069f);
	                    scale = new Vector3(0.4798435f, 0.3944988f, 0.4798435f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.64f, -1.05f, 5.76f);
	                    rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
	                    rotate = new Vector3(9.63f,49.048f,-7.454f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.03f, 3.72f, 11.97f);
	                    rotate = new Vector3(-1.599f, 40.463f, -36.884f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(0.87f, 1.47f, 11.97f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(6.22f, 4.7f, 12.09f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(1.072769f, 0.8819671f, 1.072769f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.48f, 3.845f, -0.71f);
	                    rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-7.16f, 2.71f, -5.11f);
	                    rotate = new Vector3(12.142f,-221.2f,-9.414f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.6f, 8.54f, 15.02f);
	                    rotate = new Vector3(8.802f, 122.863f, -47.972f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(6.59f, 7.08f, 5.56f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(6.46f, 4.35f, 5.45f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        }
	    } else if (eyeType == "TWO") {
	        if (finType == "ZERO") {
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);

	    				rotate = new Vector3(-27.355f, 0f, 0f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        location = new Vector3(12.1f, 2.56f, -0.61f);
				        rotate = new Vector3(9.432f, -38.081f, 174.741f);
				        scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.69f, 1.77f, 3.95f);
				        rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
				        scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(18.33f, 0f, -1.08f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-19.7f, 1.88f, 3.83f);
				        rotate = new Vector3(-50.778f, 30.267f, -25.559f);
				        scale = new Vector3(1f, 1f, 1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
				        rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.789f, -0.49f, 1.14f);
				        rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.51f, 0f, 0f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-0.95f, 0f, -0.5f);
				    	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
				        rotate = new Vector3(-193.602f,12.96599f,-183.372f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {        //bodyType == "THREE"
	        		if (tailType == "ONE") {

	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(1.71f, 1.24f, 3.49f);
				     	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(0.79602f,0.79602f,0.79602f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.49f, -0.21f, 2.67f);
				        rotate = new Vector3(-3.461f,-54.807f,-29.341f);
				        scale = new Vector3(0.91773f,0.91773f,0.91773f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.64f, -1.05f, 5.76f);
				     	rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
				        rotate = new Vector3(9.63f,49.048f,-7.454f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.48f, 3.845f, -0.71f);
				     	rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				       location = new Vector3(-7.16f, 2.71f, -5.11f);
				        rotate = new Vector3(12.142f,-221.2f,-9.414f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        } else if (finType == "ONE") {
	        	GameObject fin1;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);

	    				rotate = new Vector3(-27.355f, 0f, 0f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        location = new Vector3(12.1f, 2.56f, -0.61f);
				        rotate = new Vector3(9.432f, -38.081f, 174.741f);
				        scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 1.58f, -4.05f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.69f, 1.77f, 3.95f);
				        rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
				        scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(18.33f, 0f, -1.08f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 2.26f, 0.15f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-19.7f, 1.88f, 3.83f);
				        rotate = new Vector3(-50.778f, 30.267f, -25.559f);
				        scale = new Vector3(1f, 1f, 1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
				        rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-18.5f, 4.11f, -2.14f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;
				        
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 0f, 0f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.789f, -0.49f, 1.14f);
				        rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.51f, 0f, 0f);
				        rotate = new Vector3(0f,0f,0f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-11.49f, 1.8f, 0.77f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-0.95f, 0f, -0.5f);
				    	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
				        rotate = new Vector3(-193.602f,12.96599f,-183.372f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(0f, 0f, 0f);
				        rotate = new Vector3(0f, 0f, 0f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(1.71f, 1.24f, 3.49f);
				     	rotate = new Vector3(0f,0f,0f);
	    				scale = new Vector3(0.79602f,0.79602f,0.79602f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(7.49f, -0.21f, 2.67f);
				        rotate = new Vector3(-3.461f,-54.807f,-29.341f);
				        scale = new Vector3(0.91773f,0.91773f,0.91773f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-2.1f, 2.7f, 17.1f);
				        rotate = new Vector3(6.576f, 102.42f, -10.861f);
				        scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-3.64f, -1.05f, 5.76f);
				     	rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
				        rotate = new Vector3(9.63f,49.048f,-7.454f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-12.03f, 3.72f, 11.97f);
				        rotate = new Vector3(-1.599f, 40.463f, -36.884f);
				        scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	    				Vector3 rotate = new Vector3(0f,0f,0f);
	    				Vector3 scale = new Vector3(1f,1f,1f);
	    				
	    				location = new Vector3(-2.48f, 3.845f, -0.71f);
				     	rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	    				scale = new Vector3(1f,1f,1f);
	        			body = create_body(location, rotate, scale, finalColor);
				        body.transform.parent = parentObj.transform;			      
				        
				        location = new Vector3(-7.16f, 2.71f, -5.11f);
				        rotate = new Vector3(12.142f,-221.2f,-9.414f);
				        scale = new Vector3(1f,1f,1f);
				        tail = create_tail(location, rotate, scale, finalColor);
				        tail.transform.parent = parentObj.transform;

				        location = new Vector3(-3.6f, 8.54f, 15.02f);
				        rotate = new Vector3(8.802f, 122.863f, -47.972f);
				        scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
				        fin1 = create_fin(location, rotate, scale, finalColor);
				        fin1.transform.parent = parentObj.transform;

				        location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        }   else if (finType == "TWO") {
	        	GameObject fin1;
	        	GameObject fin2;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);

	                    rotate = new Vector3(-27.355f, 0f, 0f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    location = new Vector3(12.1f, 2.56f, -0.61f);
	                    rotate = new Vector3(9.432f, -38.081f, 174.741f);
	                    scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 1.54f, -4.18f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(2.71f, 4.03f, -4.27f);
	                    rotate = new Vector3(16.778f, 3.849f, -1.314f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.69f, 1.77f, 3.95f);
	                    rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
	                    scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(18.33f, 0f, -1.08f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 2.26f, 0.15f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-1.39f, 1.88f, 2.07f);
	                    rotate = new Vector3(0f, 35.358f, 0f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-19.7f, 1.88f, 3.83f);
	                    rotate = new Vector3(-50.778f, 30.267f, -25.559f);
	                    scale = new Vector3(1f, 1f, 1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
	                    rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-18.5f, 4.11f, -2.14f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-16.92f, 5.16f, -0.67f);
	                    rotate = new Vector3(16.78f, 10.108f, -1.101f);
	                    scale = new Vector3(0.8162609f, 0.6710809f, 0.8162609f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;           

	                    location = new Vector3(8.47f, -3.49f, 12.23f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.789f, -0.49f, 1.14f);
	                    rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.51f, 0f, 0f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-11.49f, 1.8f, 0.77f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-4.84f, -0.76f, 13.79f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-0.95f, 0f, -0.5f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
	                    rotate = new Vector3(-193.602f,12.96599f,-183.372f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(3.61f, -1.86f, 12.52f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {

	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(1.71f, 1.24f, 3.49f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(0.79602f,0.79602f,0.79602f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.49f, -0.21f, 2.67f);
	                    rotate = new Vector3(-3.461f,-54.807f,-29.341f);
	                    scale = new Vector3(0.91773f,0.91773f,0.91773f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-2.1f, 2.7f, 17.1f);
	                    rotate = new Vector3(6.576f, 102.42f, -10.861f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 3.26f, 8.85f);
	                    rotate = new Vector3(4.751f, 257.713f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.64f, -1.05f, 5.76f);
	                    rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
	                    rotate = new Vector3(9.63f,49.048f,-7.454f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.03f, 3.72f, 11.97f);
	                    rotate = new Vector3(-1.599f, 40.463f, -36.884f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(0.87f, 1.47f, 11.97f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.48f, 3.845f, -0.71f);
	                    rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-7.16f, 2.71f, -5.11f);
	                    rotate = new Vector3(12.142f,-221.2f,-9.414f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.6f, 8.54f, 15.02f);
	                    rotate = new Vector3(8.802f, 122.863f, -47.972f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(6.59f, 7.08f, 5.56f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	}
	        }   else if (finType == "THREE") {
	        	GameObject fin1;
	        	GameObject fin2;
	        	GameObject fin3;
	        	if (bodyType == "ONE") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);

	                    rotate = new Vector3(-27.355f, 0f, 0f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    location = new Vector3(12.1f, 2.56f, -0.61f);
	                    rotate = new Vector3(9.432f, -38.081f, 174.741f);
	                    scale = new Vector3(0.7968004f, 0.7968004f, 0.7968004f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.86f, -0.58f, -3.22f);
	                    rotate = new Vector3(-3.087f, 22.315f, 20.209f);
	                    scale = new Vector3(0.96172f, 0.96172f, 0.96172f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.78f, 8.73f, -0.26f);
	                    rotate = new Vector3(55.528f, 2.395f, -2.223f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(9.67f, -0.59f, -2.72f);
	                    rotate = new Vector3(-27.379f, -15.156f, -163.207f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(0.82f, 1.89f, 4.74f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(0.98f, 2.85f, 4.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.69f, 1.77f, 3.95f);
	                    rotate = new Vector3(-11.149f, 18.609f, -10.5741f);
	                    scale = new Vector3(1.3128f, 1.3128f, 1.3128f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(18.33f, 0f, -1.08f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.91f, 4.95f, 0.1f);
	                    rotate = new Vector3(29.106f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-1.39f, 1.88f, 2.07f);
	                    rotate = new Vector3(0f, 35.358f, 0f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(4.18f, -0.15f, 16.61f);
	                    rotate = new Vector3(-27.579f, 211.611f, -175.451f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-0.31f, 3.68f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-0.31f, 1.55f, 9.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-19.7f, 1.88f, 3.83f);
	                    rotate = new Vector3(-50.778f, 30.267f, -25.559f);
	                    scale = new Vector3(1f, 1f, 1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-0.678618f, -2.072895f, 5.467682f);
	                    rotate = new Vector3(-176.322f,-8.138977f,17.65099f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-18.5f, 4.11f, -2.14f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-19.39f, 5.58f, 1.58f);
	                    rotate = new Vector3(16.78f, 10.108f, -1.101f);
	                    scale = new Vector3(0.6056002f, 0.4978882f, 0.6056002f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.57f, -4.3f, 7.55f);
	                    rotate = new Vector3(-108.761f, 44.14099f, -52.54901f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-17.17f, 5.91f, 6.04f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-17.17f, 5.4f, 6.96f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else if (bodyType == "TWO") {
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;
	                    
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;           

	                    location = new Vector3(5.8f, 5.42f, 7.07f);
	                    rotate = new Vector3(74.34901f, 202.613f, 237.952f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(13.61f, -6.56f, 9.9f);
	                    rotate = new Vector3(-110.18f, 39.04399f, 133.112f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(10.01f, 1.15f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(10.01f, -1.27f, 7.11f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.789f, -0.49f, 1.14f);
	                    rotate = new Vector3(-11.354f, 4.377f, 168.892f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.51f, 0f, 0f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-11.49f, 1.8f, 0.77f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(-4.84f, -0.76f, 13.79f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(-9.62f, 9.88f, 6.27f);
	                    rotate = new Vector3(72.62701f, 135.814f, 208.531f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.16f, 3.71f, 7.66f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-12.6f, 1.75f, 8.35f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {   //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-0.95f, 0f, -0.5f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-11.97956f, 0.1972464f, 6.143659f);
	                    rotate = new Vector3(-193.602f,12.96599f,-183.372f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(0f, 0f, 0f);
	                    rotate = new Vector3(0f, 0f, 0f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(3.61f, -1.86f, 12.52f);
	                    rotate = new Vector3(-29.771f, 161.222f, -0.923f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(8.21f, 7.15f, 9.26f);
	                    rotate = new Vector3(42.911f, -152.46f, -44.454f);
	                    scale = new Vector3(0.91f, 0.7481475f, 0.91f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(8.69f, 1.328f, 6.05f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(8.92f, -1.23f, 6.25f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		}
	        	} else {       //bodyType == "THREE"
	        		if (tailType == "ONE") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(1.71f, 1.24f, 3.49f);
	                    rotate = new Vector3(0f,0f,0f);
	                    scale = new Vector3(0.79602f,0.79602f,0.79602f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(7.49f, -0.21f, 2.67f);
	                    rotate = new Vector3(-3.461f,-54.807f,-29.341f);
	                    scale = new Vector3(0.91773f,0.91773f,0.91773f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-2.1f, 2.7f, 17.1f);
	                    rotate = new Vector3(6.576f, 102.42f, -10.861f);
	                    scale = new Vector3(0.9622021f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(7.52f, 2.85f, 8.81f);
	                    rotate = new Vector3(29.038f, -117.783f, -34.069f);
	                    scale = new Vector3(0.4798435f, 0.3944988f, 0.4798435f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(7.61f, 6.2f, 9.26f);
	                    rotate = new Vector3(29.038f, -117.783f, -34.069f);
	                    scale = new Vector3(0.4798435f, 0.3944988f, 0.4798435f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(1.78f, 2.51f, 12.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(1.64f, -0.26f, 12.65f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else if (tailType == "TWO") {
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-3.64f, -1.05f, 5.76f);
	                    rotate = new Vector3(-17.201f,-28.598f,-23.746f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-1.466859f, -2.889514f, -0.7826221f);
	                    rotate = new Vector3(9.63f,49.048f,-7.454f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-12.03f, 3.72f, 11.97f);
	                    rotate = new Vector3(-1.599f, 40.463f, -36.884f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(0.87f, 1.47f, 11.97f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(6.22f, 4.7f, 12.09f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(1.072769f, 0.8819671f, 1.072769f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-8.45f, 3.9f, 15.14f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-9.58f, 0.66f, 15.17f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;

	        		} else {    //tailType == "THREE"
	        			Vector3 location = new Vector3(0f,0f,0f);
	                    Vector3 rotate = new Vector3(0f,0f,0f);
	                    Vector3 scale = new Vector3(1f,1f,1f);
	                    
	                    location = new Vector3(-2.48f, 3.845f, -0.71f);
	                    rotate = new Vector3(-0.005f,-0.463f,-0.097f);
	                    scale = new Vector3(1f,1f,1f);
	                    body = create_body(location, rotate, scale, finalColor);
	                    body.transform.parent = parentObj.transform;                  
	                    
	                    location = new Vector3(-7.16f, 2.71f, -5.11f);
	                    rotate = new Vector3(12.142f,-221.2f,-9.414f);
	                    scale = new Vector3(1f,1f,1f);
	                    tail = create_tail(location, rotate, scale, finalColor);
	                    tail.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.6f, 8.54f, 15.02f);
	                    rotate = new Vector3(8.802f, 122.863f, -47.972f);
	                    scale = new Vector3(0.717562f, 0.9622021f, 0.9622021f);
	                    fin1 = create_fin(location, rotate, scale, finalColor);
	                    fin1.transform.parent = parentObj.transform;

	                    location = new Vector3(6.59f, 7.08f, 5.56f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin2 = create_fin(location, rotate, scale, finalColor);
	                    fin2.transform.parent = parentObj.transform;

	                    location = new Vector3(6.46f, 4.35f, 5.45f);
	                    rotate = new Vector3(4.751f, -102.287f, -29.437f);
	                    scale = new Vector3(0.6644287f, 0.5462537f, 0.6644287f);
	                    fin3 = create_fin(location, rotate, scale, finalColor);
	                    fin3.transform.parent = parentObj.transform;

	                    location = new Vector3(-3.08f, 5.03f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        leftEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						leftEye.transform.localScale = scale;
						leftEye.transform.position = location;
						Renderer rendLE = leftEye.GetComponent<Renderer>();
						rendLE.material.color = new Color (0f,0f,0f,1.0f);
						leftEye.transform.parent = parentObj.transform;

						location = new Vector3(-3.08f, 2.66f, 10.41f);
				        scale = new Vector3(0.5f, 0.5f, 0.5f);
				        rightEye = GameObject.CreatePrimitive(PrimitiveType.Cube);
						rightEye.transform.localScale = scale;
						rightEye.transform.position = location;
						Renderer rendRE = rightEye.GetComponent<Renderer>();
						rendRE.material.color = new Color (0f,0f,0f,1.0f);
						rightEye.transform.parent = parentObj.transform;
	        		}
	        	}
	        }
	    }

        
	}
}
