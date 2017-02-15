using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : IHolder {
	private void Start () {
        side = SIDE.TOP;
        rend = GetComponent<Renderer>();
	}

}
