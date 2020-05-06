/*
Anum Bhamani
I have created desert. To have a desert texture I have not only created bumps(high and lows) but also I have created linings 
to make it look like actual desert.
Also, for colors I am using random range in Y to get more naturalistic and variation in colors within my terrain. 
It seems one color but paying closer attention redish/orange shades can be seen
I have created my cactus by randomizing the location (random x and z) within terrain. Also. to get the plant texture I have imported an image and wrapped it around the cactus I have created.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMotion : MonoBehaviour {

	int max_plane = -1;       // the number of planes that we've made
	
	Camera MainCamera;

	public int texture_width = 85;
	public int texture_height = 85;
	public GameObject camera;
	float scale = 10;

	private int seed; 

	private Vector3[] verts;  // the vertices of the mesh
	private int[] tris; 

	public GameObject cactus;
	int xsize,zsize;
	int plane_size;
	int currI, currJ;
	bool[,] list = new bool[200,200];

	

	void Start () {
		xsize = 85;
		zsize = 85;
		plane_size = 85;
		currI = 0;
		currJ = 0;

		list[currI + 50, currJ + 50] = true; 
		CreateMyMesh(0,0,0);
		// cache the main camera
		MainCamera = Camera.main;
	}
	
	// Move the camera, and maybe create a new plane
	void Update () {

		// get the horizontal and verticle controls (arrows, or WASD keys)
		float dx = Input.GetAxis ("Horizontal");
		float dz = Input.GetAxis ("Vertical");

		//Debug.LogFormat ("dx dz: {0} {1}", dx, dz);

		// sensitivity factors for translate and rotate
		float translate_factor = 0.3f;
		float rotate_factor = 5.0f;

		// translate forward or backwards
		MainCamera.transform.Translate (0, 0, dz * translate_factor);

		// rotate left or right
		MainCamera.transform.Rotate (0, dx * rotate_factor, 0);

		// grab the main camera position
		Vector3 cam_pos = MainCamera.transform.position;

		currI = (int) System.Math.Floor(((cam_pos.x + (plane_size / 2f)) / (float) plane_size));
		currJ = (int) System.Math.Floor(((cam_pos.z + (plane_size / 2f)) / (float) plane_size));


		if(!(list[(currI + 50),(currJ + 50)])){
			CreateMyMesh((((currI) * plane_size) - currI), 0, (((currJ) * plane_size) - currJ));
			list[(currI + 50),(currJ + 50)] = true;
		}
	}


	// create a texture using Perlin noise
	Texture2D make_a_texture() {

		// create the texture and an array of colors that will be copied into the texture
		Texture2D texture = new Texture2D (texture_width, texture_height);
		Color[] colors = new Color[texture_width * texture_height];

		texture.wrapMode = TextureWrapMode.Clamp;


		// create the Perlin noise pattern in "colors"
		for (int i = 0; i < texture_width; i++)
			for (int j = 0; j < texture_height; j++) {
				colors [j * texture_width + i] = new Color (.90f, Random.Range(0.5f, 0.55f), .24f, 1.0f);
			}

		// copy the colors into the texture
		texture.SetPixels(colors);

		// do texture-y stuff, probably including making the mipmap levels
		texture.Apply();

		// return the texture
		return (texture);
	}

	// create a mesh that consists of two triangles that make up a quad
	// Mesh CreateMyMesh(float xmin, float zmin, float xmax, float zmax) {
	Mesh CreateMyMesh(float xNew, float yNew, float zNew) {
		//cactus
		int num_cactus = 2;

		for (int n = 0; n < num_cactus; n++) {
			GameObject c = (GameObject)Instantiate(cactus);
			float t = n / (float) num_cactus * 10;    // t in range [0,1]
			c.transform.localScale = new Vector3 (1,1,1);
			c.transform.position = new Vector3 (Random.Range(0f + xNew ,30f + xNew) + (n * 4), 3, Random.Range(0f + zNew, 30f + zNew));
			
		}
		



		int index1 = max_plane + 1;
		// increment the number of planes that we've created
		max_plane++;
		// create a mesh object
		Mesh mesh = new Mesh();

		
		// create a new GameObject and give it a MeshFilter and a MeshRenderer
		GameObject s = new GameObject("Textured Mesh");
		s.name = index1.ToString("Desert 0");  // give this plane a name
		s.AddComponent<MeshFilter>();
		s.AddComponent<MeshRenderer>();

		// associate my mesh with this object
		s.GetComponent<MeshFilter>().mesh = mesh;

		// change the color of the object
		Renderer rend = s.GetComponent<Renderer>();
		
		// create a texture
		Texture2D texture = make_a_texture();

		float xterrain = (xNew - (plane_size / 2));
		float zterrain = (zNew - (plane_size / 2));


		s.transform.position = new Vector3 (xterrain, yNew, zterrain);

		// attach the texture to the mesh
		Renderer renderer = s.GetComponent<Renderer>();
		renderer.material.mainTexture = texture;

		int vertexCount = (xsize + 1) * (zsize + 1);
		// vertices 
		verts = new Vector3[vertexCount];

		// create uv coordinates
		Vector2[] uv = new Vector2[vertexCount];

		
		int i = 0;
		for (int z = 0; z <= zsize; z++) {
			for (int x = 0; x <= xsize; x++) {			
				float perl1 = Mathf.PerlinNoise(.06f * (x + xNew), .06f * (z + zNew));
				float perl2 = 0.5f * Mathf.PerlinNoise(.05f * (x + xNew), .05f * (z + zNew));
				float perl3 = 0.15f * Mathf.PerlinNoise(.3f * (x + xNew), .3f * (z + zNew));
				float y = (5f* perl1) + (perl2) + (perl3);
				if (x % 2 == 0) {
					y-= 0.5f;					
				}
				verts[i] = new Vector3(x, y, z);
				uv[i] = new Vector2((float)x/(float)xsize, (float)z/(float)zsize);
				i++;
			}
		}

		tris = new int[xsize * zsize * 6];
		
		int ntris = 0;
		int index = 0;
		
		for (int z = 0; z < zsize; z++) {
			for (int x = 0; x < xsize; x++) {
				tris[index + 0] = ntris + 0;
				tris[index + 1] = ntris + xsize + 1;
				tris[index + 2] = ntris + 1;
				tris[index + 3] = ntris + 1;
				tris[index + 4] = ntris + xsize + 1;
				tris[index + 5] = ntris + xsize + 2;

				ntris++;
				index +=6;	
			}
			ntris++;
		}

		
		// save the vertices and triangles in the mesh object
		mesh.vertices = verts;
		mesh.triangles = tris;
		mesh.uv = uv;  // save the uv texture coordinates

		mesh.RecalculateNormals();  // automatically calculate the vertex normals

		

		return (mesh);
	}
}

