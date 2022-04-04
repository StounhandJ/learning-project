package com.example.workwithsqlite;

import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class DatabaseHelper extends SQLiteOpenHelper {

    public SQLiteDatabase DB;
    public DatabaseHelper(Context context) {
        super(context, "Userdata.db", null, 1);
        DB = this.getWritableDatabase();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("create Table UserInfo(name TEXT primary key, phone TEXT, date_of_birth TEXT)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("drop Table if exists UserInfo");
    }

    public Boolean insert(String name, String phone, String date_of_birth) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("name", name);
        contentValues.put("phone", phone);
        contentValues.put("date_of_birth", date_of_birth);
        long result = DB.insert("UserInfo", null, contentValues);
        return result != -1;
    }

    public Cursor getdata(){
        return DB.rawQuery("Select * from UserInfo", null);
    }

    public Boolean delete(String name)
    {
        long result = DB.delete("UserInfo", "name = '" + name + "'", null);
        return result != -1;
    }

    public Boolean update(String name, String phone, String date_of_birth) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("phone", phone);
        contentValues.put("date_of_birth", date_of_birth);
        long result = DB.update("UserInfo", contentValues, "name=?", new String[]{name});
        return result != -1;
    }
}
