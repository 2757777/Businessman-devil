using UnityEngine;
using System.Collections.Generic;

public class TestWorld : MonoBehaviour 
{
	public GameObject cubeObject;
	public GameObject pathObject;

	public Camera mainCamera;
	public SceneGrid sceneGrid;

	private AStarUtils _aStarUtils;

	private AStarNode _beginNode, _endNode;

	private int _cols = 20;
	private int _rows = 20;

    private GameObject _moveableObj;

    private bool _isMoving = false;

    private IList<AStarNode> _path = null;
    private int _nowPosIndex = 0;

    private float _timer = 0.1f;

    void Awake()
	{
        _aStarUtils = new AStarUtils (_cols, _rows);
        _moveableObj = Instantiate(pathObject);

		// cols
		for(int i = 0; i < _cols; i++)
		{
			// rows
			for(int j = 0; j < _rows; j++)
			{
				AStarUnit aStarUnit = new AStarUnit();

				if(i != 0 && j != 0 && Random.Range(1, 10) <= 3)
				{
					aStarUnit.isPassable = false;

					GameObject gameObject = Instantiate(cubeObject);
					if(gameObject != null)
					{
						gameObject.transform.localPosition = new Vector3(i - this._cols * 0.5f + 0.5f, 0f, j - this._cols * 0.5f + 0.5f);
					}

				}else{
					aStarUnit.isPassable = true;
				}

                _aStarUtils.GetNode(i,j).AddUnit(aStarUnit);
			}
		}
	}

	private IList<AStarNode> FindPath(int x, int y)
	{
		_endNode = _aStarUtils.GetNode(x, y);

		if (_beginNode == null) 
		{
            _beginNode = _endNode;
			return null;
		}
		
		if(_endNode != null && _endNode.walkable)
		{
			System.DateTime dateTime = System.DateTime.Now;

			IList<AStarNode> pathList = _aStarUtils.FindPath(this._beginNode, _endNode);

			System.DateTime currentTime = System.DateTime.Now;

			System.TimeSpan timeSpan = currentTime.Subtract(dateTime);

			Debug.Log(timeSpan.Seconds + "秒" + timeSpan.Milliseconds + "毫秒");

            return pathList;
		}
        return null;
	}
	
	void Update()
	{
        if (_isMoving)
        {
            if (_timer >= 0.1f)
            {
                _timer = 0f;

                if (_nowPosIndex >= 0 && _path != null)
                {
                    Debug.Log(_path[_nowPosIndex].nodeX + " " + _path[_nowPosIndex].nodeY);
                    _moveableObj.transform.localPosition = new Vector3(_path[_nowPosIndex].nodeX - _cols * 0.5f + 0.5f, 0f, _path[_nowPosIndex].nodeY - _cols * 0.5f + 0.5f);
                    _nowPosIndex--;
                }
                else
                {
                    _isMoving = false;
                }
            }
            _timer += Time.deltaTime;
        }
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);

			RaycastHit raycastHit = new RaycastHit();
			if(Physics.Raycast(ray, out raycastHit))
			{
				if(raycastHit.collider.gameObject.tag == "Plane")
				{
					Vector3 pointItem = this.sceneGrid.transform.InverseTransformPoint(raycastHit.point) * 2f;

					pointItem.x = this._cols * 0.5f + Mathf.Ceil(pointItem.x) - 1f;
					pointItem.z = this._cols * 0.5f + Mathf.Ceil(pointItem.z) - 1f;

                    if (_path != null && _path.Count > 0)
                    {
                        _beginNode = _nowPosIndex < 0 ? _endNode : _path[_nowPosIndex];
                    }
					_path = this.FindPath((int)pointItem.x, (int)pointItem.z);
                    _nowPosIndex = _path == null ? 0 : _path.Count - 1;

                    if (_path != null)
                    {
                        foreach (var item in _path)
                        {
                            Debug.Log(item.nodeX + " " + item.nodeY + "\n");
                        }
                    }
				}
			}

            if (_path != null && _path.Count > 0)
            {
                _isMoving = true;
            }
		}
	}
}
