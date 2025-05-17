#define FLIP // Comment out this line to flip the landmarks (internally).
// NOTE: image = cv2.flip(image, 1) in the Python side may also be of interest to you as well.

#if FLIP
public enum Landmark
{
    NOSE = 0,
    RIGHT_EYE_INNER = 4,
    RIGHT_EYE = 5,
    RIGHT_EYE_OUTER = 6,
    LEFT_EYE_INNER = 1,
    LEFT_EYE = 2,
    LEFT_EYE_OUTER = 3,
    RIGHT_EAR = 8,
    LEFT_EAR = 7,
    MOUTH_RIGHT = 10,
    MOUTH_LEFT = 9,

    RIGHT_SHOULDER = 12,   // เปลี่ยนให้ตรงกับ HumanBodyBones.RightShoulder
    LEFT_SHOULDER = 11,    // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftShoulder
    RIGHT_ELBOW = 16,      // เปลี่ยนให้ตรงกับ HumanBodyBones.RightLowerArm
    LEFT_ELBOW = 15,       // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftLowerArm
    RIGHT_WRIST = 18,      // เปลี่ยนให้ตรงกับ HumanBodyBones.RightHand
    LEFT_WRIST = 17,       // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftHand

    RIGHT_THUMB = 22,      // เปลี่ยนให้ตรงกับ HumanBodyBones.RightThumbProximal
    LEFT_THUMB = 21,       // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftThumbProximal
    RIGHT_INDEX = 20,      // เปลี่ยนให้ตรงกับ HumanBodyBones.RightIndexProximal
    LEFT_INDEX = 19,       // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftIndexProximal
    RIGHT_PINKY = 51,      // เปลี่ยนให้ตรงกับ HumanBodyBones.RightLittleProximal
    LEFT_PINKY = 36,       // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftLittleProximal

    RIGHT_HIP = 24,         // เปลี่ยนให้ตรงกับ HumanBodyBones.RightUpperLeg
    LEFT_HIP = 23,          // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftUpperLeg
    RIGHT_KNEE = 26,        // เปลี่ยนให้ตรงกับ HumanBodyBones.RightLowerLeg
    LEFT_KNEE = 25,         // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftLowerLeg
    RIGHT_ANKLE = 28,       // เปลี่ยนให้ตรงกับ HumanBodyBones.RightFoot
    LEFT_ANKLE = 27,        // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftFoot
    RIGHT_HEEL = 30,       // เปลี่ยนให้ตรงกับ HumanBodyBones.RightHeel
    LEFT_HEEL = 29,        // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftHeel
    RIGHT_FOOT_INDEX = 32, // เปลี่ยนให้ตรงกับ HumanBodyBones.RightToes
    LEFT_FOOT_INDEX = 31,  // เปลี่ยนให้ตรงกับ HumanBodyBones.LeftToes

    //NONE = 40
}

#else
public enum Landmark
{
    NOSE = 0,
    LEFT_EYE_INNER = 1,
    LEFT_EYE = 2,
    LEFT_EYE_OUTER = 3,
    RIGHT_EYE_INNER = 4,
    RIGHT_EYE = 5,
    RIGHT_EYE_OUTER = 6,
    LEFT_EAR = 7,
    RIGHT_EAR = 8,
    MOUTH_LEFT = 9,
    MOUTH_RIGHT = 10,
    LEFT_SHOULDER = 11,
    RIGHT_SHOULDER = 12,
    LEFT_ELBOW = 13,
    RIGHT_ELBOW = 14,
    LEFT_WRIST = 15,
    RIGHT_WRIST = 16,
    LEFT_PINKY = 17,
    RIGHT_PINKY = 18,
    LEFT_INDEX = 19,
    RIGHT_INDEX = 20,
    LEFT_THUMB = 21,
    RIGHT_THUMB = 22,
    LEFT_HIP = 23,
    RIGHT_HIP = 24,
    LEFT_KNEE = 25,
    RIGHT_KNEE = 26,
    LEFT_ANKLE = 27,
    RIGHT_ANKLE = 28,
    LEFT_HEEL = 29,
    RIGHT_HEEL = 30,
    LEFT_FOOT_INDEX = 31,
    RIGHT_FOOT_INDEX = 32,
    NONE = 40
}
#endif