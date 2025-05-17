1. การติดตั้งโปรแกรมและ Library ที่จำเป็น

โปรเจกต์นี้ต้องการการติดตั้งโปรแกรมและ Library ต่อไปนี้:
-Unity (เวอร์ชันที่ใช้พัฒนา: 2022.3 หรือสูงกว่า)
-Python (เวอร์ชัน 3.9 ขึ้นไป)
-MediaPipe (pip install mediapipe)
-OpenCV (pip install opencv-python)
-Numpy (pip install numpy)

2. โครงสร้างไฟล์
📦Project
 ┣ 📂Assets              # ไฟล์ Assets ของ Unity
 ┣ 📂Library             # ไฟล์ Library ของ Unity
 ┣ 📂Logs                # Logs ต่าง ๆ
 ┣ 📂Packages            # ไฟล์ Package ของ Unity
 ┣ 📂ProjectSettings     # การตั้งค่า Project ของ Unity
 ┣ 📂UserSettings        # การตั้งค่า User ของ Unity
 ┣ 📂PythonScripts       # โฟลเดอร์เก็บไฟล์ Python
 ┃ ┗ 📜main.py          # สคริปต์หลักในการประมวลผล MediaPipe และส่งข้อมูล
 ┣ 📜MyProject.sln       # ไฟล์ Solution ของ Unity
 ┗ 📜README.md           # ไฟล์คู่มือการใช้งาน

3. วิธีการรันโปรแกรม
 1.เปิด Unity และเปิดโปรเจกต์นี้
 2.เปิดไฟล์ Scene หลักที่ต้องการทดสอบ
 3.รันคำสั่งต่อไปนี้ใน Command Prompt หรือ Terminal เพื่อรัน MediaPipe:

  cd PythonScripts
  python main.py

 4.กด Play ที่ Unity เพื่อเริ่มการทำงาน

 
