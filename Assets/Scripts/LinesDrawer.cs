using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
	public static LinesDrawer instance;

	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;

	[Space(30f)]
	public Gradient dynamicLineColor;
	public Gradient staticLineColor;
	public float linePointsMinDistance;
	public float lineWidth;
	[HideInInspector] public int linesPointCount;

	Line currentLine;
	Camera cam;
	bool isDynamicPencil;

    private void Awake()
    {
		instance = this;
    }

    void Start()
	{
		cam = Camera.main;
		cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
	}

	void Update()
	{
		if (PauseUI.instance != null)
		{
			if (PauseUI.instance.isPaused)
				return;
		}
		isDynamicPencil = CoreGameUI.instance.isDynamic;
		if (Input.GetMouseButtonDown(0))
			BeginDraw();

		if (currentLine != null)
			Draw();

		if (Input.GetMouseButtonUp(0))
			EndDraw();
	}

	// Begin Draw ----------------------------------------------
	void BeginDraw()
	{
		currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

		//Set line properties
		currentLine.UsePhysics(false);
		if (isDynamicPencil)
		{
			currentLine.SetLineColor(dynamicLineColor);
			currentLine.isDynamic = true;
		}
        else
        {
			currentLine.SetLineColor(staticLineColor);
			currentLine.isDynamic = false;
        }
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);

	}
	// Draw ----------------------------------------------------
	void Draw()
	{
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

		if (hit)
			EndDraw();
		else
			currentLine.AddPoint(mousePosition);
	}
	// End Draw ------------------------------------------------
	void EndDraw()
	{
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				//If line has one point
				Destroy(currentLine.gameObject);
			}
			else
			{
				Time.timeScale = 1;
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;
				currentLine.DestroyLine();

				//Activate Physics on the line
				if (isDynamicPencil)
				{
					currentLine.UsePhysics(true);
				}

				currentLine = null;
			}
		}
	}
}
