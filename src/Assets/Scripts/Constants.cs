using UnityEngine;
/* Contains useful constants for other classes to use for their calculations.
 * Unity does not seem to support "const", so we have to make do with public static variables.
 */
public class Constant {
	public static float screenWidthHalf = Camera.main.aspect * Camera.main.orthographicSize;
	public static float screenHeightHalf = Camera.main.orthographicSize;
}
