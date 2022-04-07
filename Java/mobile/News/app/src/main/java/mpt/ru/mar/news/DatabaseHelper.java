package mpt.ru.mar.news;


import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {

    public SQLiteDatabase DB;

    public DatabaseHelper(Context context) {
        super(context, "Userdata.db", null, 1);
        DB = this.getWritableDatabase();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create Table UserInfo(name TEXT primary key, password TEXT, is_admin INTEGER)");
        db.execSQL("create Table NewsInfo(name TEXT, date_created TEXT primary key)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("drop Table if exists UserInfo");
        db.execSQL("drop Table if exists NewsInfo");
    }

    public Boolean insertUser(String name, String phone, Integer is_admin) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("name", name);
        contentValues.put("password", phone);
        contentValues.put("is_admin", is_admin);
        long result = DB.insert("UserInfo", null, contentValues);
        return result != -1;
    }

    public Cursor getUsers() {
        return DB.rawQuery("Select * from UserInfo", null);
    }

    public Cursor getUserByLoginPassword(String name, String password) {

        return DB.rawQuery("Select * from UserInfo where name='"+name+"' and password='"+password+"'", null);
    }

    public Boolean deleteUser(String name) {
        long result = DB.delete("UserInfo", "name = '" + name + "'", null);
        return result != -1;
    }

    public Boolean updateUser(String name, String phone, String date_of_birth) {
//        ContentValues contentValues = new ContentValues();
//        contentValues.put("phone", phone);
//        contentValues.put("date_of_birth", date_of_birth);
//        long result = DB.update("UserInfo", contentValues, "name=?", new String[]{name});
//        return result != -1;
        return false;
    }

    public Boolean insertNews(String name, String date_created) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("name", name);
        contentValues.put("date_created", date_created);
        long result = DB.insert("NewsInfo", null, contentValues);
        return result != -1;
    }

    public Cursor getNews() {
        return DB.rawQuery("Select * from NewsInfo", null);
    }

    public Boolean deleteNews(String date_created) {
        long result = DB.delete("NewsInfo", "name = '" + date_created + "'", null);
        return result != -1;
    }

    public Boolean updateNews(String date_created, String name) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("name", name);
        long result = DB.update("NewsInfo", contentValues, "date_created=?", new String[]{date_created});
        return result != -1;
    }
}

