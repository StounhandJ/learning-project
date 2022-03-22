package mpt.ru.mar.practic;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class ResultActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_result);

        Bundle bundle = getIntent().getExtras();
        TextView tw1 = findViewById(R.id.textViewRes);
        TextView tw2 = findViewById(R.id.textViewDes);
        tw1.setText(String.valueOf(bundle.getDouble("result", -1.0)));
        tw2.setText(bundle.getString("des"));

        Button btn = findViewById(R.id.buttonNext);
        btn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                finish();
            }
        });
    }
}