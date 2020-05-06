//Effort: Colorful trails and butterflies, Added background, Animated butterflies's wings
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flocking : MonoBehaviour {
    public GameObject butterflyPrefab;
    public GameObject BLUEbutterflyPrefab;
    public GameObject PURPLEbutterflyPrefab;
    public GameObject ORANGEbutterflyPrefab;
    public GameObject YELLOWbutterflyPrefab;

    public GameObject grass;

    public GameObject linePrefab;

    List<Boid> boidsList = new List<Boid>();

    [Range(30, 500)]
    public int numButterflies = 97;

    public bool isFlockCentering = true;
    public bool isVelocityMatching = true;
    public bool isCollisionAvoidance = true;
    public bool isWandering = true;
    public bool isTrail = true;

    public float centerWeight = 0.4f;
    public float collisionWeight = 0.1f;
    public float matchingWeight = 0.001f;
    public float wanderingWeight = 4f;

    public float radius = 50f;
    public float collisionRadius = 20f;

    public float minMagVel = 25f;
    public float maxMagVel = 50f;

    string type;

    public int animationCount;
    
    
    void Start() {
        animationCount = 0;

        GameObject plane = (GameObject)Instantiate(grass);
        plane.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        plane.transform.position = new Vector3(0f, -4f, 0f);

        for (int i = 0; i < numButterflies; i++) {
            GameObject b;

            if (i % 2 == 0) {
                b = (GameObject)Instantiate(BLUEbutterflyPrefab);
                type = "BLUE";
            } else if (i % 3 == 0){
                b = (GameObject)Instantiate(butterflyPrefab);
                type = "RED";
            } else if (i % 5 == 0){
                b = (GameObject)Instantiate(PURPLEbutterflyPrefab);
                type = "PURPLE";
            } else if (i % 7 == 0) {
                b = (GameObject)Instantiate(YELLOWbutterflyPrefab);
                type = "YELLOW";
            } else {
                b = (GameObject)Instantiate(ORANGEbutterflyPrefab);
                type = "ORANGE";
            }
            b.transform.localScale = new Vector3(5,5,5);

            Vector3 newPos = new Vector3(Random.Range(-200f, 200f), 0f, Random.Range(-200f, 200f));
            Vector3 newVel = new Vector3(Random.Range(-1.0f,1f), 0f, Random.Range(-1f,1f));
            b.transform.position = newPos;
            
            Boid boidButterfly = new Boid(b, newPos, newVel);
            boidsList.Add(boidButterfly);
            boidButterfly.butterflyType = type;
            
       }
       
    }

    // Update is called once per frame
    void Update() {        
        Vector3 flockCenteringV = new Vector3(0,0,0); 
        Vector3 velocityMatchingV = new Vector3(0,0,0);
        Vector3 collisionAvoidanceV = new Vector3(0,0,0);
        Vector3 wanderingV = new Vector3(0,0,0);        

        foreach(Boid boid in boidsList) {
            
            //spaceBar
            if (Input.GetKeyDown("space")) {                 
                boid.position = new Vector3(Random.Range(-200f, 200f), 0f, Random.Range(-200f, 200f));
                boid.velocity = new Vector3(Random.Range(-1.0f,1f), 0f, Random.Range(-1f,1f));
                boid.queue.Clear();
            }

            //four forces
            if (isFlockCentering) {
                flockCenteringV = flockCenter(boid);
            }
            
            if (isCollisionAvoidance) {
                collisionAvoidanceV = avoidCollision(boid);
            }

            if (isVelocityMatching) {
                velocityMatchingV = velocityMatching(boid);
            }

            if (isWandering) {
                wanderingV = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            }

            boid.velocity = boid.velocity + (flockCenteringV * centerWeight) + (collisionAvoidanceV * collisionWeight) 
                             + (velocityMatchingV * matchingWeight) + (wanderingV * wanderingWeight);

            //if too fast
            if (boid.velocity.magnitude > maxMagVel) {
                boid.velocity = (boid.velocity / boid.velocity.magnitude) * maxMagVel;
            }

            //too slow
            if (boid.velocity.magnitude < minMagVel) {
                if (boid.velocity.magnitude != 0) {
                    boid.velocity = (boid.velocity / boid.velocity.magnitude) * minMagVel;
                } else {
                    boid.velocity = new Vector3(boid.velocity.x + 0.001f, 0f, boid.velocity.z + 0.001f);
                    boid.velocity = (boid.velocity / boid.velocity.magnitude) * minMagVel;
                }             
            }

            boid.position = boid.position + (boid.velocity * Time.deltaTime);


            //Trails
            boid.queue.Enqueue(boid.position);
            boid.trailCapacity++;
            Vector3[] points = boid.queue.ToArray();
            boid.lineRenderer.positionCount = boid.queue.Count;
            boid.lineRenderer.SetPositions(points);

            if (boid.butterflyType == "RED") {
                Color c1 = Color.red;
                Color c2 = Color.red;
                boid.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                boid.lineRenderer.SetColors(c1, c2);
            } else if (boid.butterflyType == "ORANGE") {
                Color c1 = new Color(1.0f, 0.64f, 0.0f);
                Color c2 = new Color(1.0f, 0.64f, 0.0f);
                boid.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                boid.lineRenderer.SetColors(c1, c2);
            } else if (boid.butterflyType == "BLUE") {
                Color c1 = Color.blue;
                Color c2 = Color.blue;
                boid.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                boid.lineRenderer.SetColors(c1, c2);
            } else if (boid.butterflyType == "PURPLE") {
                Color c1 = new Color((143f/255f), 0f, (254f/255f));
                Color c2 = new Color((143f/255f), 0f, (254f/255f));
                boid.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                boid.lineRenderer.SetColors(c1, c2);
            } else {   //yellow
                Color c1 = Color.yellow;
                Color c2 = Color.yellow;
                boid.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                boid.lineRenderer.SetColors(c1, c2);
            }

            if (boid.queue.Count == 50f) {
                boid.queue.Dequeue();
            }

            if(isTrail) {
                boid.lineRenderer.enabled = true;
            } else {
                boid.lineRenderer.enabled = false;
            }    

            // wall collision check                  
            if (boid.position.x >= 300f) {
                float sub = boid.position.x - 300f;
                boid.position.x = 300f - sub;
                boid.velocity.x = -1 * boid.velocity.x;                
            }

            if (boid.position.x <= -300f) {
                float sub = boid.position.x + 300f;
                boid.position.x = -300f - sub;
                boid.velocity.x = -1 * boid.velocity.x;            
            }

            if (boid.position.z >= 300f) {
                float sub = boid.position.z - 300f;
                boid.position.z = 300f - sub;
                boid.velocity.z = -1 * boid.velocity.z;
            }

            if (boid.position.z <= -300f) {
                float sub = boid.position.z + 300f;
                boid.position.z = -300f - sub;
                boid.velocity.z = -1 * boid.velocity.z;
            }

            boid.butterfly.transform.position = boid.position;

           //orientation
            boid.butterfly.transform.forward = Vector3.Lerp(boid.butterfly.transform.forward, boid.velocity, Time.deltaTime);              
           
            //animation
            animationCount++;
            GameObject upperRWingsObj = boid.butterfly.transform.GetChild (1).gameObject;
            GameObject upperLWingsObj = boid.butterfly.transform.GetChild (2).gameObject;
            GameObject lowerRWingsObj = boid.butterfly.transform.GetChild (3).gameObject;
            GameObject lowerLWingsObj = boid.butterfly.transform.GetChild (4).gameObject;

            if(animationCount % 200 < 100) {
                upperRWingsObj.transform.Rotate(0f, 0f, 25f, Space.Self);
                upperLWingsObj.transform.Rotate(0f, 0f, -25f, Space.Self);                
            } else {
                upperRWingsObj.transform.Rotate(0f, 0f, -25f, Space.Self);
                upperLWingsObj.transform.Rotate(0f, 0f, 25f, Space.Self);
            }

            if (animationCount % 100 < 50) {
                lowerRWingsObj.transform.Rotate(0f, 0f, -25f, Space.Self);
                lowerLWingsObj.transform.Rotate(0f, 0f, 25f, Space.Self);
            } else {
                lowerRWingsObj.transform.Rotate(0f, 0f, 25f, Space.Self);
                lowerLWingsObj.transform.Rotate(0f, 0f, -25f, Space.Self);
            }

            
        }
    }

    Vector3 flockCenter(Boid boid) {
        float weightSum = 0.0f;
        float weight;
        Vector3 sumDis = new Vector3(0,0,0);

        foreach(Boid b in boidsList) { 
            if(b != boid) {                
                float dist = Vector3.Distance(b.position, boid.position);
                Vector3 displacement = b.position - boid.position;

                //calculate ind weight
                weight = Mathf.Max(0, (radius - dist));
                weightSum += weight;
                sumDis = sumDis + weight * displacement;
            }
            
        }
        if (weightSum != 0) {
            sumDis = sumDis / weightSum;
        } else {
            sumDis = new Vector3(0,0,0);
        }

        return sumDis;
    }

    Vector3 avoidCollision(Boid boid) {
        float weightSum = 0.0f;
        float weight;
        Vector3 sumDis = new Vector3(0,0,0);

        foreach(Boid b in boidsList) {
            if (b!= boid) {
                 Vector3 displacement = boid.position - b.position;
                if (displacement.magnitude < collisionRadius) {
                    float dist = Vector3.Distance(b.position, boid.position);

                    //calculate ind weight
                    weight = Mathf.Max(0, (radius - dist));
                    weightSum += weight;
                    sumDis = sumDis + weight * displacement; 
                }
            }
        }
        return sumDis;
    }

    Vector3 velocityMatching(Boid boid) {
      float weightSum = 0.0f;
        float weight;
        Vector3 sumDis = new Vector3(0,0,0);

        foreach(Boid b in boidsList) {         
            if(b != boid) {                
                float dist = Vector3.Distance(b.position, boid.position);
                Vector3 displacment = b.velocity - boid.velocity;

                //calculate ind weight
                weight = Mathf.Max(0, (radius - dist));
                weightSum += weight;
                sumDis = sumDis + weight * displacment;
            }          
        }
        return sumDis;
    }
}

public class Boid {
    public GameObject butterfly;
    public Vector3 position;
    public Vector3 velocity;
    public Queue<Vector3> queue = new Queue<Vector3>();

    public LineRenderer lineRenderer;

    public float trailCapacity = 50f;

    public string butterflyType = "";

    public Boid(GameObject butterfly, Vector3 position, Vector3 velocity) {
        this.butterfly = butterfly;
        this.position = position;
        this.velocity = velocity;
        queue.Enqueue(position);
        lineRenderer = butterfly.AddComponent<LineRenderer>();
        Vector3[] points = queue.ToArray();
        lineRenderer.positionCount = queue.Count;
        lineRenderer.SetPositions(points);
    }


}
